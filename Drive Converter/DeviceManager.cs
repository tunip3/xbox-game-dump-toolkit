using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace XBOX_One_Drive_Converter
{
	// Token: 0x02000003 RID: 3
	internal class DeviceManager
	{
		// Token: 0x06000004 RID: 4
		[DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern uint SetFilePointer([In] SafeFileHandle hFile, [In] int lDistanceToMove, IntPtr high, [In] DeviceManager.EMoveMethod dwMoveMethod);

		// Token: 0x06000005 RID: 5
		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		private static extern SafeFileHandle CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);

		// Token: 0x06000006 RID: 6
		[DllImport("kernel32", SetLastError = true)]
		internal static extern int ReadFile(SafeFileHandle handle, byte[] bytes, int numBytesToRead, out int numBytesRead, IntPtr overlapped_MustBeZero);

		// Token: 0x06000007 RID: 7
		[DllImport("kernel32", SetLastError = true)]
		internal static extern int WriteFile(SafeFileHandle handle, byte[] bytes, int numBytesToWrite, out int numBytesWritten, IntPtr overlapped_MustBeZero);

		// Token: 0x06000008 RID: 8 RVA: 0x000023B0 File Offset: 0x000005B0
		public static List<DeviceManager.XBOX_External_Storage_Device> ParsePhysicalDrives()
		{
			int num = 0;
			List<DeviceManager.XBOX_External_Storage_Device> list = new List<DeviceManager.XBOX_External_Storage_Device>();
			byte[] array = new byte[512];
			using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive"))
			{
				foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
				{
					string text = (string)managementBaseObject["DeviceID"];
					SafeFileHandle safeFileHandle = DeviceManager.CreateFile(text, 2147483648u, 1u, IntPtr.Zero, 3u, 0u, IntPtr.Zero);
					if (safeFileHandle.IsInvalid)
					{
						safeFileHandle.Close();
					}
					else
					{
						DeviceManager.ReadFile(safeFileHandle, array, 512, out num, IntPtr.Zero);
						byte[] first = new byte[]
						{
							array[510],
							array[511]
						};
						DeviceManager.XBOX_External_Storage_Device xbox_External_Storage_Device = new DeviceManager.XBOX_External_Storage_Device();
						xbox_External_Storage_Device.DeviceName = text;
						xbox_External_Storage_Device.DeviceCaption = (string)managementBaseObject["Caption"];
						if (first.SequenceEqual(DeviceManager.XBOX_Signature))
						{
							xbox_External_Storage_Device.DeviceMode = "XBOX Mode";
							list.Add(xbox_External_Storage_Device);
						}
						else if (first.SequenceEqual(DeviceManager.PC_Signature))
						{
							bool flag = true;
							for (int i = 0; i < 440; i++)
							{
								if (array[i] != 0)
								{
									flag = false;
									break;
								}
							}
							if (flag)
							{
								xbox_External_Storage_Device.DeviceMode = "PC Mode";
								list.Add(xbox_External_Storage_Device);
							}
						}
						safeFileHandle.Close();
					}
				}
			}
			return list;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002564 File Offset: 0x00000764
		public static void ChangeDeviceMode(string deviceName, DeviceManager.DeviceMode mode)
		{
			byte[] array = new byte[512];
			int num = 0;
			int num2 = 0;
			SafeFileHandle safeFileHandle = DeviceManager.CreateFile(deviceName, 3221225472u, 0u, IntPtr.Zero, 3u, 0u, IntPtr.Zero);
			if (safeFileHandle.IsInvalid)
			{
				safeFileHandle.Close();
			}
			DeviceManager.ReadFile(safeFileHandle, array, 512, out num, IntPtr.Zero);
			byte[] first = new byte[]
			{
				array[510],
				array[511]
			};
			if (mode == DeviceManager.DeviceMode.Xbox && first.SequenceEqual(DeviceManager.PC_Signature))
			{
				array[510] = DeviceManager.XBOX_Signature[0];
				array[511] = DeviceManager.XBOX_Signature[1];
			}
			else
			{
				if (mode != DeviceManager.DeviceMode.PC || !first.SequenceEqual(DeviceManager.XBOX_Signature))
				{
					safeFileHandle.Close();
					return;
				}
				array[510] = DeviceManager.PC_Signature[0];
				array[511] = DeviceManager.PC_Signature[1];
			}
			DeviceManager.SetFilePointer(safeFileHandle, 0, IntPtr.Zero, DeviceManager.EMoveMethod.Begin);
			DeviceManager.WriteFile(safeFileHandle, array, 512, out num2, IntPtr.Zero);
			safeFileHandle.Close();
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002668 File Offset: 0x00000868
		public static void FormatLogicalDrive(DriveInfo drive)
		{
			if (drive.DriveType != DriveType.Removable && drive.DriveType != DriveType.Fixed)
			{
				throw new DeviceManager.UnsupportedDriveTypeException();
			}
			string text = drive.Name.Remove(2);
			if (drive.DriveFormat != "NTFS")
			{
				Process process = Process.Start(new ProcessStartInfo
				{
					FileName = "format.com",
					Arguments = text + " /Y /fs:NTFS /V:XBOX_EXTERNAL /Q",
					UseShellExecute = false,
					CreateNoWindow = true,
					RedirectStandardOutput = true,
					RedirectStandardInput = true
				});
				process.WaitForExit();
				if (process.ExitCode != 0)
				{
					throw new Exception(process.StandardError.ReadToEnd());
				}
			}
			string deviceNameFromLogicalPath = DeviceManager.getDeviceNameFromLogicalPath(text);
			DeviceManager.ChangeDeviceMode(deviceNameFromLogicalPath, DeviceManager.DeviceMode.Xbox);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002720 File Offset: 0x00000920
		private static string getDeviceNameFromLogicalPath(string logicalId)
		{
			using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive"))
			{
				foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
				{
					string queryString = string.Format("ASSOCIATORS OF {{Win32_DiskDrive.DeviceID='{0}'}} WHERE AssocClass = Win32_DiskDriveToDiskPartition", (string)managementBaseObject["DeviceID"]);
					using (ManagementObjectSearcher managementObjectSearcher2 = new ManagementObjectSearcher(queryString))
					{
						foreach (ManagementBaseObject managementBaseObject2 in managementObjectSearcher2.Get())
						{
							queryString = string.Format("ASSOCIATORS OF {{Win32_DiskPartition.DeviceID='{0}'}} WHERE AssocClass = Win32_LogicalDiskToPartition", (string)managementBaseObject2["DeviceID"]);
							using (ManagementObjectSearcher managementObjectSearcher3 = new ManagementObjectSearcher(queryString))
							{
								foreach (ManagementBaseObject managementBaseObject3 in managementObjectSearcher3.Get())
								{
									string a = (string)managementBaseObject3["Caption"];
									if (a == logicalId)
									{
										string text = (string)managementBaseObject["DeviceID"];
										if ((uint)managementBaseObject["Index"] == 0u)
										{
											throw new DeviceManager.BootDriveFormatException();
										}
										return (string)managementBaseObject["DeviceID"];
									}
								}
							}
						}
					}
				}
			}
			throw new DeviceManager.DeviceNotFoundException();
		}

		// Token: 0x04000007 RID: 7
		private const short FILE_ATTRIBUTE_NORMAL = 128;

		// Token: 0x04000008 RID: 8
		private const short INVALID_HANDLE_VALUE = -1;

		// Token: 0x04000009 RID: 9
		private const uint GENERIC_READ = 2147483648u;

		// Token: 0x0400000A RID: 10
		private const uint GENERIC_WRITE = 1073741824u;

		// Token: 0x0400000B RID: 11
		private const uint CREATE_NEW = 1u;

		// Token: 0x0400000C RID: 12
		private const uint CREATE_ALWAYS = 2u;

		// Token: 0x0400000D RID: 13
		private const uint OPEN_EXISTING = 3u;

		// Token: 0x0400000E RID: 14
		private const int MBR_SIGNATURE_SIZE = 2;

		// Token: 0x0400000F RID: 15
		private const int MBR_SIGNATURE_OFFSET = 510;

		// Token: 0x04000010 RID: 16
		private const int MBR_SIZE = 512;

		// Token: 0x04000011 RID: 17
		private static readonly byte[] XBOX_Signature = new byte[]
		{
			153,
			204
		};

		// Token: 0x04000012 RID: 18
		private static readonly byte[] PC_Signature = new byte[]
		{
			85,
			170
		};

		// Token: 0x02000004 RID: 4
		[Flags]
		public enum EFileShare : uint
		{
			// Token: 0x04000014 RID: 20
			None = 0u,
			// Token: 0x04000015 RID: 21
			Read = 1u,
			// Token: 0x04000016 RID: 22
			Write = 2u,
			// Token: 0x04000017 RID: 23
			Delete = 4u
		}

		// Token: 0x02000005 RID: 5
		private enum EMoveMethod : uint
		{
			// Token: 0x04000019 RID: 25
			Begin,
			// Token: 0x0400001A RID: 26
			Current,
			// Token: 0x0400001B RID: 27
			End
		}

		// Token: 0x02000006 RID: 6
		public enum DeviceMode
		{
			// Token: 0x0400001D RID: 29
			Xbox,
			// Token: 0x0400001E RID: 30
			PC
		}

		// Token: 0x02000007 RID: 7
		public class XBOX_External_Storage_Device
		{
			// Token: 0x0400001F RID: 31
			public string DeviceName;

			// Token: 0x04000020 RID: 32
			public string DeviceCaption;

			// Token: 0x04000021 RID: 33
			public string DeviceMode;
		}

		// Token: 0x02000008 RID: 8
		public class UnsupportedDriveTypeException : Exception
		{
		}

		// Token: 0x02000009 RID: 9
		private class DeviceNotFoundException : Exception
		{
		}

		// Token: 0x0200000A RID: 10
		public class BootDriveFormatException : Exception
		{
		}
	}
}
