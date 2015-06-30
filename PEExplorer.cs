using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace PEReader
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class PEExplorer : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.TabPage headersTab;
		private System.Windows.Forms.TabPage directoriesTab;
		private System.Windows.Forms.ListView listView2;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.TabControl sectionTabs;
		private System.Windows.Forms.TabPage sectionHeadersTab;
		private System.Windows.Forms.ListView listView3;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ColumnHeader columnHeader13;
		private System.Windows.Forms.ColumnHeader columnHeader14;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		// Create PE Reader Class
		PEReader pr = new PEReader();

		public PEExplorer()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PEExplorer));
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.sectionTabs = new System.Windows.Forms.TabControl();
			this.headersTab = new System.Windows.Forms.TabPage();
			this.directoriesTab = new System.Windows.Forms.TabPage();
			this.listView2 = new System.Windows.Forms.ListView();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.sectionHeadersTab = new System.Windows.Forms.TabPage();
			this.listView3 = new System.Windows.Forms.ListView();
			this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.sectionTabs.SuspendLayout();
			this.headersTab.SuspendLayout();
			this.directoriesTab.SuspendLayout();
			this.sectionHeadersTab.SuspendLayout();
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1,
																						this.columnHeader2});
			this.listView1.FullRowSelect = true;
			this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView1.Location = new System.Drawing.Point(8, 8);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(440, 328);
			this.listView1.TabIndex = 2;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Property Name";
			this.columnHeader1.Width = 229;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Value";
			this.columnHeader2.Width = 180;
			// 
			// sectionTabs
			// 
			this.sectionTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.sectionTabs.Controls.Add(this.headersTab);
			this.sectionTabs.Controls.Add(this.directoriesTab);
			this.sectionTabs.Controls.Add(this.sectionHeadersTab);
			this.sectionTabs.Location = new System.Drawing.Point(8, 8);
			this.sectionTabs.Name = "sectionTabs";
			this.sectionTabs.SelectedIndex = 0;
			this.sectionTabs.Size = new System.Drawing.Size(464, 368);
			this.sectionTabs.TabIndex = 3;
			// 
			// headersTab
			// 
			this.headersTab.Controls.Add(this.listView1);
			this.headersTab.Location = new System.Drawing.Point(4, 22);
			this.headersTab.Name = "headersTab";
			this.headersTab.Size = new System.Drawing.Size(456, 342);
			this.headersTab.TabIndex = 0;
			this.headersTab.Text = "Headers";
			// 
			// directoriesTab
			// 
			this.directoriesTab.Controls.Add(this.listView2);
			this.directoriesTab.Location = new System.Drawing.Point(4, 22);
			this.directoriesTab.Name = "directoriesTab";
			this.directoriesTab.Size = new System.Drawing.Size(456, 342);
			this.directoriesTab.TabIndex = 1;
			this.directoriesTab.Text = "Directories";
			// 
			// listView2
			// 
			this.listView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader5,
																						this.columnHeader6,
																						this.columnHeader7,
																						this.columnHeader3});
			this.listView2.FullRowSelect = true;
			this.listView2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView2.Location = new System.Drawing.Point(8, 8);
			this.listView2.MultiSelect = false;
			this.listView2.Name = "listView2";
			this.listView2.Size = new System.Drawing.Size(440, 328);
			this.listView2.TabIndex = 3;
			this.listView2.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Type";
			this.columnHeader5.Width = 173;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Virtual Address";
			this.columnHeader6.Width = 89;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "Size";
			this.columnHeader7.Width = 84;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Present";
			// 
			// sectionHeadersTab
			// 
			this.sectionHeadersTab.Controls.Add(this.listView3);
			this.sectionHeadersTab.Location = new System.Drawing.Point(4, 22);
			this.sectionHeadersTab.Name = "sectionHeadersTab";
			this.sectionHeadersTab.Size = new System.Drawing.Size(456, 342);
			this.sectionHeadersTab.TabIndex = 2;
			this.sectionHeadersTab.Text = "Section Headers";
			// 
			// listView3
			// 
			this.listView3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader11,
																						this.columnHeader13,
																						this.columnHeader14,
																						this.columnHeader4,
																						this.columnHeader8});
			this.listView3.FullRowSelect = true;
			this.listView3.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView3.Location = new System.Drawing.Point(8, 7);
			this.listView3.MultiSelect = false;
			this.listView3.Name = "listView3";
			this.listView3.Size = new System.Drawing.Size(440, 328);
			this.listView3.TabIndex = 4;
			this.listView3.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader11
			// 
			this.columnHeader11.Text = "Name";
			this.columnHeader11.Width = 70;
			// 
			// columnHeader13
			// 
			this.columnHeader13.Text = "Virtual Address";
			this.columnHeader13.Width = 88;
			// 
			// columnHeader14
			// 
			this.columnHeader14.Text = "Virtual Size";
			this.columnHeader14.Width = 69;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Raw Data Pointer";
			this.columnHeader4.Width = 100;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "Raw Data Size";
			this.columnHeader8.Width = 84;
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem2,
																					  this.menuItem3,
																					  this.menuItem4,
																					  this.menuItem5});
			this.menuItem1.Text = "File";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "Open EXE...";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Text = "Close";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 2;
			this.menuItem4.Text = "-";
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 3;
			this.menuItem5.Text = "Exit";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Filter = "Executable Files|*.exe|All Files|*.*";
			this.openFileDialog1.Title = "Open Executable File";
			// 
			// PEExplorer
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(480, 385);
			this.Controls.Add(this.sectionTabs);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMenu1;
			this.Name = "PEExplorer";
			this.Text = "PE Explorer Sample Application";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.sectionTabs.ResumeLayout(false);
			this.headersTab.ResumeLayout(false);
			this.directoriesTab.ResumeLayout(false);
			this.sectionHeadersTab.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new PEExplorer());
		}

		private void button1_Click(object sender, System.EventArgs e)
		{

		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}

		private void AddHeaderInformation(string name, string value)
		{
			ListViewItem lvi = listView1.Items.Add(name);
			lvi.SubItems.Add(value);
		}

		private void AddDirectoryInfo(string type, uint virtualAddress, uint size)
		{
			ListViewItem lvi = listView2.Items.Add(type);
			lvi.SubItems.Add(string.Format("{0:X8}", virtualAddress));
			lvi.SubItems.Add(string.Format("{0:X8}", size));
			lvi.SubItems.Add((virtualAddress > 0 ? "Yes" : "No"));
		}

		private void AddSectionHeaderInfo(string name, uint physicalAddress, uint virtualAddress, uint virtualSize, uint rawDataPointer, uint rawDataSize)
		{
			ListViewItem lvi = listView3.Items.Add(name);
			lvi.SubItems.Add(string.Format("{0:X8}", virtualAddress));
			lvi.SubItems.Add(string.Format("{0:X8}", virtualSize));
			lvi.SubItems.Add(string.Format("{0:X8}", rawDataPointer));
			lvi.SubItems.Add(string.Format("{0:X8}", rawDataSize));
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			openFileDialog1.ShowDialog();
			if(openFileDialog1.FileName.Length > 0)
			{
				pr.LoadExecutable(openFileDialog1.FileName);

				listView1.Items.Clear();
				listView2.Items.Clear();
				listView3.Items.Clear();

				AddHeaderInformation("DOS Header Information", String.Empty);
				AddHeaderInformation("Magic", pr.DOSHeader.Magic.ToString());
				AddHeaderInformation("Size of Last Page", pr.DOSHeader.SizeOfLastPage.ToString());
				AddHeaderInformation("Number of Pages", pr.DOSHeader.NumberOfPages.ToString());
				AddHeaderInformation("Relocations", pr.DOSHeader.Relocations.ToString());
				AddHeaderInformation("Size of Header", pr.DOSHeader.SizeOfHeader.ToString());
				AddHeaderInformation("Minimum Extra Paragraphs", pr.DOSHeader.MinimumExtraParagraphs.ToString());
				AddHeaderInformation("Maximum Extra Paragraphs", pr.DOSHeader.MaximumExtraParagraphs.ToString());
				AddHeaderInformation("Initial SS Value", pr.DOSHeader.InitialSSValue.ToString());
				AddHeaderInformation("Initial SP Value", pr.DOSHeader.InitialSPValue.ToString());
				AddHeaderInformation("Checksum", pr.DOSHeader.Checksum.ToString());
				AddHeaderInformation("Initial IP Value", pr.DOSHeader.InitialIPValue.ToString());
				AddHeaderInformation("Initial CS Value", pr.DOSHeader.InitialCSValue.ToString());
				AddHeaderInformation("Relocation Table Address", pr.DOSHeader.RelocationTableAddress.ToString());
				AddHeaderInformation("Overlay Number", pr.DOSHeader.OverlayNumber.ToString());
				AddHeaderInformation("OEM Identifier", pr.DOSHeader.OemIdentifier.ToString());
				AddHeaderInformation("OEM Information", pr.DOSHeader.OemInformation.ToString());
				AddHeaderInformation("PE Header Offset", pr.DOSHeader.PEHeaderAddress.ToString());
				AddHeaderInformation(String.Empty, String.Empty);

				AddHeaderInformation("PE Header Information", String.Empty);
				AddHeaderInformation("Magic", String.Format("{0:X4}", pr.PEHeader.Magic));
				AddHeaderInformation("Major Linker Version", pr.PEHeader.MajorLinkerVersion.ToString());
				AddHeaderInformation("Minor Linker Version", pr.PEHeader.MinorLinkerVersion.ToString());
				AddHeaderInformation("Size of Code", pr.PEHeader.SizeOfCode.ToString());
				AddHeaderInformation("Size Of Initialized Data", pr.PEHeader.SizeOfInitializedData.ToString());
				AddHeaderInformation("Size Of Uninitialized Data", pr.PEHeader.SizeOfUninitializedData.ToString());
				AddHeaderInformation("Address Of Entry Point", pr.PEHeader.AddressOfEntryPoint.ToString());
				AddHeaderInformation("Base Of Code", pr.PEHeader.BaseOfCode.ToString());
				AddHeaderInformation("Base Of Data", pr.PEHeader.BaseOfData.ToString());
				AddHeaderInformation("Image Base", pr.PEHeader.ImageBase.ToString());
				AddHeaderInformation("Section Alignment", pr.PEHeader.SectionAlignment.ToString());
				AddHeaderInformation("File Alignment", pr.PEHeader.FileAlignment.ToString());
				AddHeaderInformation("Major Operating System Version", pr.PEHeader.MajorOperatingSystemVersion.ToString());
				AddHeaderInformation("Minor Operating System Version", pr.PEHeader.MinorOperatingSystemVersion.ToString());
				AddHeaderInformation("Major Image Version", pr.PEHeader.MajorImageVersion.ToString());
				AddHeaderInformation("Minor Image Version", pr.PEHeader.MinorImageVersion.ToString());
				AddHeaderInformation("Major Subsystem Version", pr.PEHeader.MajorSubsystemVersion.ToString());
				AddHeaderInformation("Minor Subsystem Version", pr.PEHeader.MinorSubsystemVersion.ToString());
				AddHeaderInformation("Win32 Version Value", pr.PEHeader.Win32VersionValue.ToString());
				AddHeaderInformation("Size Of Image", pr.PEHeader.SizeOfImage.ToString());
				AddHeaderInformation("Size Of Headers", pr.PEHeader.SizeOfHeaders.ToString());
				AddHeaderInformation("CheckSum", pr.PEHeader.CheckSum.ToString());
				AddHeaderInformation("Subsystem", pr.PEHeader.Subsystem.ToString());
				AddHeaderInformation("DLL Characteristics", pr.PEHeader.DllCharacteristics.ToString());
				AddHeaderInformation("Size Of Stack Reserve", pr.PEHeader.SizeOfStackReserve.ToString());
				AddHeaderInformation("Size Of Stack Commit", pr.PEHeader.SizeOfStackCommit.ToString());
				AddHeaderInformation("Size Of Heap Reserve", pr.PEHeader.SizeOfHeapReserve.ToString());
				AddHeaderInformation("Size Of Heap Commit", pr.PEHeader.SizeOfHeapCommit.ToString());
				AddHeaderInformation("Loader Flags", pr.PEHeader.LoaderFlags.ToString());
				AddHeaderInformation("Number Of Data Directories", pr.PEHeader.NumberOfRvaAndSizes.ToString());

				// Fill the directories list
				for(int i = 0; i < 16; i++)
					AddDirectoryInfo(pr.DataDirectories[i].Type, pr.DataDirectories[i].VirtualAddress, pr.DataDirectories[i].Size);
		
				// Fill the directories list
				for(int i = 0; i < pr.SectionHeaders.Length; i++)
					AddSectionHeaderInfo( pr.SectionHeaders[i].Name, pr.SectionHeaders[i].PhysicalAddress, pr.SectionHeaders[i].VirtualAddress, pr.SectionHeaders[i].VirtualSize, pr.SectionHeaders[i].PointerToRawData, pr.SectionHeaders[i].SizeOfRawData);

				//FileStream fs = new FileStream(Application.ExecutablePath.Replace("PEReader.exe", "rsrc.bin"),FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
				//byte[] resourceData = pr.GetSectionDataByName(".rsrc");
				//fs.Write(resourceData, 0, resourceData.Length);
			}
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			pr.CloseExecutable();
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}
	}
}
