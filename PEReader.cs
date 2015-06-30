// Coded by Brandon Scott
// Version 0.01a
//
// Probely some room for improvement, this is just the first release though.
// 
// A very valuable resource for the PE file structure is located
// below.
// http://www.csn.ul.ie/~caolan/publink/winresdump/winresdump/doc/pefile.html
//
// If you do use this for something, please give me some credit.
// 
// Eventually I want to have this thing read Resource Data, and maby
// detect some of the common packers such as UPX.

using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;

namespace PEReader
{
	/// <summary>
	/// Written to make reading the information from a PE (Portable Executable)
	/// easier and simple.
	/// </summary>
	public class PEReader
	{
		#region Subsystem Values
		public const uint IMAGE_SUBSYSTEM_UNKNOWN            =  0;   // Unknown subsystem.
		public const uint IMAGE_SUBSYSTEM_NATIVE             =  1;   // Image doesn't require a subsystem.
		public const uint IMAGE_SUBSYSTEM_WINDOWS_GUI        =  2;   // Image runs in the Windows GUI subsystem.
		public const uint IMAGE_SUBSYSTEM_WINDOWS_CUI        =  3;   // Image runs in the Windows character subsystem.
		public const uint IMAGE_SUBSYSTEM_OS2_CUI            =  5;   // image runs in the OS/2 character subsystem.
		public const uint IMAGE_SUBSYSTEM_POSIX_CUI          =  7;   // image runs in the Posix character subsystem.
		public const uint IMAGE_SUBSYSTEM_NATIVE_WINDOWS     =  8;   // image is a native Win9x driver.
		public const uint IMAGE_SUBSYSTEM_WINDOWS_CE_GUI     =  9;   // Image runs in the Windows CE subsystem.
		public const uint IMAGE_SUBSYSTEM_EFI_APPLICATION    =  10;  //
		public const uint IMAGE_SUBSYSTEM_EFI_BOOT_SERVICE_DRIVER = 11;   //
		public const uint IMAGE_SUBSYSTEM_EFI_RUNTIME_DRIVER  = 12;  //
		public const uint IMAGE_SUBSYSTEM_EFI_ROM            =  13;
		public const uint IMAGE_SUBSYSTEM_XBOX               =  14;
		#endregion

		#region DllCharacteristics Entries
		public const uint IMAGE_DLLCHARACTERISTICS_NO_SEH    =  0x0400;     // Image does not use SEH.  No SE handler may reside in this image
		public const uint IMAGE_DLLCHARACTERISTICS_NO_BIND   =  0x0800;     // Do not bind this image.
		public const uint IMAGE_DLLCHARACTERISTICS_WDM_DRIVER = 0x2000;     // Driver uses WDM model
		public const uint IMAGE_DLLCHARACTERISTICS_TERMINAL_SERVER_AWARE  =   0x8000;
		#endregion

		#region DOS header format
		public struct IMAGE_DOS_HEADER
		{
			public ushort Magic;
			public ushort SizeOfLastPage;
			public ushort NumberOfPages;
			public ushort Relocations;
			public ushort SizeOfHeader;
			public ushort MinimumExtraParagraphs;
			public ushort MaximumExtraParagraphs;
			public ushort InitialSSValue;
			public ushort InitialSPValue;
			public ushort Checksum;
			public ushort InitialIPValue;
			public ushort InitialCSValue;
			public ushort RelocationTableAddress;
			public ushort OverlayNumber;
			//[MarshalAs(UnmanagedType.U2, SizeConst=8)]
			//public ushort[] ReservedWords;
			public ushort OemIdentifier;
			public ushort OemInformation;
			//[MarshalAs(UnmanagedType.U2, SizeConst=20)]
			//public ushort[] ReservedWords2;
			public uint PEHeaderAddress;
		}
		#endregion
		#region File header format
		public const int IMAGE_SIZEOF_FILE_HEADER            = 20;
		public struct IMAGE_FILE_HEADER
		{
			public ushort Machine;
			public ushort NumberOfSections;
			public uint TimeDateStamp;
			public uint PointerToSymbolTable;
			public uint NumberOfSymbols;
			public ushort SizeOfOptionalHeader;
			public ushort Characteristics;
		}
		public const ushort IMAGE_FILE_RELOCS_STRIPPED          = 0x0001;  // Relocation info stripped from file.
		public const ushort IMAGE_FILE_EXECUTABLE_IMAGE         = 0x0002;  // File is executable  (i.e. no unresolved externel references).
		public const ushort IMAGE_FILE_LINE_NUMS_STRIPPED       = 0x0004;  // Line nunbers stripped from file.
		public const ushort IMAGE_FILE_LOCAL_SYMS_STRIPPED      = 0x0008;  // Local symbols stripped from file.
		public const ushort IMAGE_FILE_AGGRESIVE_WS_TRIM        = 0x0010;  // Agressively trim working set
		public const ushort IMAGE_FILE_LARGE_ADDRESS_AWARE      = 0x0020;  // App can handle >2gb addresses
		public const ushort IMAGE_FILE_BYTES_REVERSED_LO        = 0x0080;  // Bytes of machine word are reversed.
		public const ushort IMAGE_FILE_32BIT_MACHINE            = 0x0100;  // 32 bit word machine.
		public const ushort IMAGE_FILE_DEBUG_STRIPPED           = 0x0200;  // Debugging info stripped from file in .DBG file
		public const ushort IMAGE_FILE_REMOVABLE_RUN_FROM_SWAP  = 0x0400;  // If Image is on removable media, copy and run from the swap file.
		public const ushort IMAGE_FILE_NET_RUN_FROM_SWAP        = 0x0800;  // If Image is on Net, copy and run from the swap file.
		public const ushort IMAGE_FILE_SYSTEM                   = 0x1000;  // System File.
		public const ushort IMAGE_FILE_DLL                      = 0x2000;  // File is a DLL.
		public const ushort IMAGE_FILE_UP_SYSTEM_ONLY           = 0x4000;  // File should only be run on a UP machine
		public const ushort IMAGE_FILE_BYTES_REVERSED_HI        = 0x8000;  // Bytes of machine word are reversed.

		public const ushort IMAGE_FILE_MACHINE_UNKNOWN    =       0;
		public const ushort IMAGE_FILE_MACHINE_I386       =       0x014c;  // Intel 386.
		public const ushort IMAGE_FILE_MACHINE_R3000      =       0x0162;  // MIPS little-endian, 0x160 big-endian
		public const ushort IMAGE_FILE_MACHINE_R4000      =       0x0166;  // MIPS little-endian
		public const ushort IMAGE_FILE_MACHINE_R10000     =       0x0168;  // MIPS little-endian
		public const ushort IMAGE_FILE_MACHINE_WCEMIPSV2  =       0x0169;  // MIPS little-endian WCE v2
		public const ushort IMAGE_FILE_MACHINE_ALPHA      =       0x0184;  // Alpha_AXP
		public const ushort IMAGE_FILE_MACHINE_SH3        =       0x01a2;  // SH3 little-endian
		public const ushort IMAGE_FILE_MACHINE_SH3DSP     =       0x01a3;
		public const ushort IMAGE_FILE_MACHINE_SH3E       =       0x01a4;  // SH3E little-endian
		public const ushort IMAGE_FILE_MACHINE_SH4        =       0x01a6;  // SH4 little-endian
		public const ushort IMAGE_FILE_MACHINE_SH5        =       0x01a8;  // SH5
		public const ushort IMAGE_FILE_MACHINE_ARM        =       0x01c0;  // ARM Little-Endian
		public const ushort IMAGE_FILE_MACHINE_THUMB      =       0x01c2;
		public const ushort IMAGE_FILE_MACHINE_AM33       =       0x01d3;
		public const ushort IMAGE_FILE_MACHINE_POWERPC    =       0x01F0;  // IBM PowerPC Little-Endian
		public const ushort IMAGE_FILE_MACHINE_POWERPCFP  =       0x01f1;
		public const ushort IMAGE_FILE_MACHINE_IA64       =       0x0200;  // Intel 64
		public const ushort IMAGE_FILE_MACHINE_MIPS16     =       0x0266;  // MIPS
		public const ushort IMAGE_FILE_MACHINE_ALPHA64    =       0x0284;  // ALPHA64
		public const ushort IMAGE_FILE_MACHINE_MIPSFPU    =       0x0366;  // MIPS
		public const ushort IMAGE_FILE_MACHINE_MIPSFPU16  =       0x0466;  // MIPS
		public const ushort IMAGE_FILE_MACHINE_AXP64      =       0x0284;
		public const ushort IMAGE_FILE_MACHINE_TRICORE    =       0x0520;  // Infineon
		public const ushort IMAGE_FILE_MACHINE_CEF        =       0x0CEF;
		public const ushort IMAGE_FILE_MACHINE_EBC        =       0x0EBC;  // EFI Byte Code
		public const ushort IMAGE_FILE_MACHINE_AMD64      =       0x8664;  // AMD64 (K8)
		public const ushort IMAGE_FILE_MACHINE_M32R       =       0x9041;  // M32R little-endian
		public const ushort IMAGE_FILE_MACHINE_CEE        =       0xC0EE;
		#endregion

		#region Directory format
		public const uint IMAGE_DIRECTORY_ENTRY_EXPORT        =  0;   // Export Directory
		public const uint IMAGE_DIRECTORY_ENTRY_IMPORT        =  1;   // Import Directory
		public const uint IMAGE_DIRECTORY_ENTRY_RESOURCE      =  2;   // Resource Directory
		public const uint IMAGE_DIRECTORY_ENTRY_EXCEPTION     =  3;   // Exception Directory
		public const uint IMAGE_DIRECTORY_ENTRY_SECURITY      =  4;   // Security Directory
		public const uint IMAGE_DIRECTORY_ENTRY_BASERELOC     =  5;   // Base Relocation Table
		public const uint IMAGE_DIRECTORY_ENTRY_DEBUG         =  6;   // Debug Directory
		public const uint IMAGE_DIRECTORY_ENTRY_COPYRIGHT    =   7;   // Copyright
		public const uint IMAGE_DIRECTORY_ENTRY_GLOBALPTR     =  8;   // RVA of GP
		public const uint IMAGE_DIRECTORY_ENTRY_TLS           =  9;   // TLS Directory
		public const uint IMAGE_DIRECTORY_ENTRY_LOAD_CONFIG   = 10;   // Load Configuration Directory
		public const uint IMAGE_DIRECTORY_ENTRY_BOUND_IMPORT  = 11;   // Bound Import Directory in headers
		public const uint IMAGE_DIRECTORY_ENTRY_IAT           = 12;   // Import Address Table
		public const uint IMAGE_DIRECTORY_ENTRY_DELAY_IMPORT  = 13;   // Delay Load Import Descriptors
		public const uint IMAGE_DIRECTORY_ENTRY_COM_DESCRIPTOR = 14;   // COM Runtime descriptor
		public const int IMAGE_NUMBEROF_DIRECTORY_ENTRIES =   16;
		public struct IMAGE_DATA_DIRECTORY
		{
			public string Type;
			public uint VirtualAddress;
			public uint Size;
		} 
		#endregion

		#region Optional header 64-bit
		public struct IMAGE_OPTIONAL_HEADER64
		{
			public ushort Magic;
			public byte MajorLinkerVersion;
			public byte MinorLinkerVersion;
			public uint SizeOfCode;
			public uint SizeOfInitializedData;
			public uint SizeOfUninitializedData;
			public uint AddressOfEntryPoint;
			public uint BaseOfCode;
			public UInt64 ImageBase;
			public uint SectionAlignment;
			public uint FileAlignment;
			public ushort MajorOperatingSystemVersion;
			public ushort MinorOperatingSystemVersion;
			public ushort MajorImageVersion;
			public ushort MinorImageVersion;
			public ushort MajorSubsystemVersion;
			public ushort MinorSubsystemVersion;
			public uint Win32VersionValue;
			public uint SizeOfImage;
			public uint SizeOfHeaders;
			public uint CheckSum;
			public ushort Subsystem;
			public ushort DllCharacteristics;
			public UInt64 SizeOfStackReserve;
			public UInt64 SizeOfStackCommit;
			public UInt64 SizeOfHeapReserve;
			public UInt64 SizeOfHeapCommit;
			public uint LoaderFlags;
			public uint NumberOfRvaAndSizes;
			public IMAGE_DATA_DIRECTORY[] DataDirectory;
		}
		#endregion

		#region Optional header 32-bit
		public struct IMAGE_OPTIONAL_HEADER32
		{
			public ushort Magic;
			public byte MajorLinkerVersion;
			public byte MinorLinkerVersion;
			public uint SizeOfCode;
			public uint SizeOfInitializedData;
			public uint SizeOfUninitializedData;
			public uint AddressOfEntryPoint;
			public uint BaseOfCode;
			public uint BaseOfData;
			public uint ImageBase;
			public uint SectionAlignment;
			public uint FileAlignment;
			public ushort MajorOperatingSystemVersion;
			public ushort MinorOperatingSystemVersion;
			public ushort MajorImageVersion;
			public ushort MinorImageVersion;
			public ushort MajorSubsystemVersion;
			public ushort MinorSubsystemVersion;
			public uint Win32VersionValue;
			public uint SizeOfImage;
			public uint SizeOfHeaders;
			public uint CheckSum;
			public ushort Subsystem;
			public ushort DllCharacteristics;
			public uint SizeOfStackReserve;
			public uint SizeOfStackCommit;
			public uint SizeOfHeapReserve;
			public uint SizeOfHeapCommit;
			public uint LoaderFlags;
			public uint NumberOfRvaAndSizes;
			public IMAGE_DATA_DIRECTORY[] DataDirectory;
		} 
		#endregion

		#region Section header format
		public struct IMAGE_SECTION_HEADER
		{
			public string Name;
			public uint PhysicalAddress;
			public uint VirtualSize;
			public uint VirtualAddress;
			public uint SizeOfRawData;
			public uint PointerToRawData;
			public uint PointerToRelocations;
			public uint PointerToLinenumbers;
			public ushort NumberOfRelocations;
			public ushort NumberOfLinenumbers;
			public uint Characteristics;
		} 
		#endregion

		private FileStream inputExe;
		private BinaryReader inputReader;
		private IMAGE_DOS_HEADER dosHeader;
		private IMAGE_FILE_HEADER fileHeader;
		private IMAGE_DATA_DIRECTORY[] dataDirectory = new IMAGE_DATA_DIRECTORY[16];
		private IMAGE_OPTIONAL_HEADER32 optionalHeader32;
		private IMAGE_SECTION_HEADER[] sectionHeaders;
		private bool isExeLoaded = false;
		//private IMAGE_OPTIONAL_HEADER64 optionalHeader64;

		private string[] directoryTypeStrings = new string[16] {"Export Table", 
																   "Import Table", 
																   "Resource Table",
																   "Exception Table",
																   "Certificate Table",
																   "Base Relocation Table",
																   "Debug Directory",
																   "Architecture Specific Data",
																   "Global Pointer Register",
																   "Thread Local Storage Table",
																   "Load Configuration Table",
																   "Bound Import Table",
																   "Import Address Table",
																   "Delay Load Import Descriptors",
																   "COM Runtime Descriptor",
																   "Reserved"};

		public IMAGE_DOS_HEADER DOSHeader
		{
			get { return dosHeader; }
		}

		public IMAGE_FILE_HEADER FileHeader
		{
			get { return fileHeader; }
		}

		public IMAGE_OPTIONAL_HEADER32 PEHeader
		{
			get { return optionalHeader32; }
		}

		public IMAGE_DATA_DIRECTORY[] DataDirectories
		{
			get { return dataDirectory; }
		}

		public IMAGE_SECTION_HEADER[] SectionHeaders
		{
			get { return sectionHeaders; }
		}

		public bool DoesSectionExist(string sectionName)
		{
			for(int i = 0; i < fileHeader.NumberOfSections; i++)
				if(sectionHeaders[i].Name == sectionName)
					return true;
			return false;
		}

		public byte[] GetSectionDataByName(string sectionName)
		{
			byte[] result;
			for(int i = 0; i < fileHeader.NumberOfSections; i++)
			{
				if(sectionHeaders[i].Name == sectionName)
				{
					inputExe.Position = sectionHeaders[i].PointerToRawData;
					result = inputReader.ReadBytes((int)sectionHeaders[i].SizeOfRawData);
					return result;
				}
			}
			return null;
		}

		public bool LoadExecutable(string fileName)
		{
			try 
			{
				inputExe = new FileStream(fileName, 
					FileMode.Open, 
					FileAccess.Read, 
					FileShare.Read);
				inputReader = new BinaryReader(inputExe);
				ReadMZHeader();
				if (dosHeader.PEHeaderAddress > 0)
				{
					inputExe.Position = dosHeader.PEHeaderAddress + 4;
					ReadFileHeader();
					ReadSectionHeaders();
				}
				isExeLoaded = true;
				return true;
			} 
			catch(Exception ex)
			{
				return false;
			}
		}

		public void CloseExecutable()
		{
			if(isExeLoaded)
				inputExe.Close();
			isExeLoaded = false;
		}

		private bool ReadMZHeader()
		{
			try 
			{
				dosHeader.Magic = inputReader.ReadUInt16();
				dosHeader.SizeOfLastPage = inputReader.ReadUInt16();
				dosHeader.NumberOfPages = inputReader.ReadUInt16();
				dosHeader.Relocations = inputReader.ReadUInt16();
				dosHeader.SizeOfHeader = inputReader.ReadUInt16();
				dosHeader.MinimumExtraParagraphs = inputReader.ReadUInt16();
				dosHeader.MaximumExtraParagraphs = inputReader.ReadUInt16();
				dosHeader.InitialSSValue = inputReader.ReadUInt16();
				dosHeader.InitialSPValue = inputReader.ReadUInt16();
				dosHeader.Checksum = inputReader.ReadUInt16();
				dosHeader.InitialIPValue = inputReader.ReadUInt16();
				dosHeader.InitialCSValue = inputReader.ReadUInt16();
				dosHeader.RelocationTableAddress = inputReader.ReadUInt16();
				dosHeader.OverlayNumber = inputReader.ReadUInt16();
				for(int i = 0; i < 4; i++)
					inputReader.ReadUInt16();
				dosHeader.OemIdentifier = inputReader.ReadUInt16();
				dosHeader.OemInformation = inputReader.ReadUInt16();
				for(int i = 0; i < 10; i++)
					inputReader.ReadUInt16();
				dosHeader.PEHeaderAddress = inputReader.ReadUInt32();
				return true;

			} 
			catch(Exception ex)
			{
				return false;
			}
		}

		private bool ReadFileHeader()
		{
			try 
			{
				fileHeader.Machine = inputReader.ReadUInt16();
				fileHeader.NumberOfSections = inputReader.ReadUInt16();
				fileHeader.TimeDateStamp = inputReader.ReadUInt32();
				fileHeader.PointerToSymbolTable = inputReader.ReadUInt32();
				fileHeader.NumberOfSymbols = inputReader.ReadUInt32();
				fileHeader.SizeOfOptionalHeader = inputReader.ReadUInt16();
				fileHeader.Characteristics = inputReader.ReadUInt16();
				if(fileHeader.SizeOfOptionalHeader > 0)
				{
					if(ReadPEHeader())
						return true;
					else
						return false;
				}
				return true;
			} 
			catch(Exception ex)
			{
				return false;
			}
		}

		private bool ReadPEHeader()
		{
			try 
			{
				optionalHeader32.Magic = inputReader.ReadUInt16();
				optionalHeader32.MajorLinkerVersion = inputReader.ReadByte();
				optionalHeader32.MinorLinkerVersion = inputReader.ReadByte();
				optionalHeader32.SizeOfCode = inputReader.ReadUInt32();
				optionalHeader32.SizeOfInitializedData = inputReader.ReadUInt32();
				optionalHeader32.SizeOfUninitializedData = inputReader.ReadUInt32();
				optionalHeader32.AddressOfEntryPoint = inputReader.ReadUInt32();
				optionalHeader32.BaseOfCode = inputReader.ReadUInt32();
				optionalHeader32.BaseOfData = inputReader.ReadUInt32();
				optionalHeader32.ImageBase = inputReader.ReadUInt32();
				optionalHeader32.SectionAlignment = inputReader.ReadUInt32();
				optionalHeader32.FileAlignment = inputReader.ReadUInt32();
				optionalHeader32.MajorOperatingSystemVersion = inputReader.ReadUInt16();
				optionalHeader32.MinorOperatingSystemVersion = inputReader.ReadUInt16();
				optionalHeader32.MajorImageVersion = inputReader.ReadUInt16();
				optionalHeader32.MinorImageVersion = inputReader.ReadUInt16();
				optionalHeader32.MajorSubsystemVersion = inputReader.ReadUInt16();
				optionalHeader32.MinorSubsystemVersion = inputReader.ReadUInt16();
				optionalHeader32.Win32VersionValue = inputReader.ReadUInt32();
				optionalHeader32.SizeOfImage = inputReader.ReadUInt32();
				optionalHeader32.SizeOfHeaders = inputReader.ReadUInt32();
				optionalHeader32.CheckSum = inputReader.ReadUInt32();
				optionalHeader32.Subsystem = inputReader.ReadUInt16();
				optionalHeader32.DllCharacteristics = inputReader.ReadUInt16();
				optionalHeader32.SizeOfStackReserve = inputReader.ReadUInt32();
				optionalHeader32.SizeOfStackCommit = inputReader.ReadUInt32();
				optionalHeader32.SizeOfHeapReserve = inputReader.ReadUInt32();
				optionalHeader32.SizeOfHeapCommit = inputReader.ReadUInt32();
				optionalHeader32.LoaderFlags = inputReader.ReadUInt32();
				optionalHeader32.NumberOfRvaAndSizes = inputReader.ReadUInt32();
				for(int i = 0; i < dataDirectory.Length; i++)
				{
					dataDirectory[i].Type = directoryTypeStrings[i];
					dataDirectory[i].VirtualAddress = inputReader.ReadUInt32();
					dataDirectory[i].Size = inputReader.ReadUInt32();
				}
				return true;

			} 
			catch(Exception ex)
			{
				return false;
			}
		}

		private bool ReadSectionHeaders()
		{
			try 
			{
				byte[] sectionNameBuffer;
				string sectionName;
				string sectionNameClean;
				sectionHeaders = new IMAGE_SECTION_HEADER[fileHeader.NumberOfSections];
				for(int i = 0; i < fileHeader.NumberOfSections; i++)
				{
					sectionNameBuffer = inputReader.ReadBytes(8);
					sectionName = Encoding.ASCII.GetString(sectionNameBuffer);
					sectionNameClean = sectionName.Substring(0, sectionName.IndexOf("\0"));
					sectionHeaders[i].Name = sectionNameClean;
					//sectionHeaders[i].PhysicalAddress = inputReader.ReadUInt32();
					sectionHeaders[i].VirtualSize = inputReader.ReadUInt32();
					sectionHeaders[i].VirtualAddress = inputReader.ReadUInt32();
					sectionHeaders[i].SizeOfRawData = inputReader.ReadUInt32();
					sectionHeaders[i].PointerToRawData = inputReader.ReadUInt32();
					sectionHeaders[i].PointerToRelocations = inputReader.ReadUInt32();
					sectionHeaders[i].PointerToLinenumbers = inputReader.ReadUInt32();
					sectionHeaders[i].NumberOfRelocations = inputReader.ReadUInt16();
					sectionHeaders[i].NumberOfLinenumbers  = inputReader.ReadUInt16();
					sectionHeaders[i].Characteristics = inputReader.ReadUInt32();
				}
				return true;

			} 
			catch(Exception ex)
			{
				return false;
			}
		}



		~PEReader()
		{
			if(isExeLoaded)
			{
				inputReader.Close();
				inputExe = null;
				inputReader = null;
			}
		}
	}
}
