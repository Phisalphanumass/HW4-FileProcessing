/*
MIT License

Copyright (c) 2026 Sarayut Chaisuriya

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
 
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

Note on dataset:
The included MalwareBazaar sample CSV has been modified:
- Limited to first 500 rows
- Header format adjusted for teaching purposes
See README.md for full details.
*/
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FileProcessing
{
	public partial class frmTextView : Form
	{
		/// <summary>
		/// Initializes a new instance of the frmTextView class.
		/// </summary>
		public frmTextView()
		{
			InitializeComponent();
		}
        /// <summary>
        /// Handles the Click event of the Read button by loading the contents of the specified file into the display area.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void btRead_Click(object sender, EventArgs e)
        {
            // เคลียร์หน้าจอแสดงผลก่อน
            rtbShow.Clear();

            string filePath = tbFileName.Text;

            // 1. ตั้งค่า m, n และ filter (สำหรับทดสอบก่อน ถ้าบนหน้าจอมี TextBox ให้เปลี่ยนไปรับค่าจาก TextBox แทนได้)
            int m = 0;
            int n = 0;

            // 1. ดึงค่าจากหน้าจอและดัก Error กรณีผู้ใช้ไม่ได้กรอกเป็นตัวเลข
            if (!int.TryParse(txtM.Text, out m) || !int.TryParse(txtN.Text, out n))
            {
                MessageBox.Show("กรุณากรอกระบุช่วงบรรทัด m และ n เป็นตัวเลขให้ถูกต้อง", "ข้อมูลไม่ถูกต้อง", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // หยุดการทำงานทันที
            }

            // 2. ดัก Error กรณีผู้ใช้ใส่ค่า m มากกว่า n (ตรงกับ Test Case TC04 พอดี!)
            if (m > n)
            {
                MessageBox.Show("ค่าบรรทัดเริ่มต้น (m) ต้องไม่มากกว่าค่าบรรทัดสิ้นสุด (n)", "ข้อมูลไม่ถูกต้อง", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. ดึงค่า Filter จากหน้าจอ (ใช้ .Trim() เพื่อตัดช่องว่างหัวท้ายทิ้งเผื่อผู้ใช้เผลอกด Spacebar)
            string filter = txtFilter.Text.Trim();

            int currentLine = 0;

            // ใช้ StringBuilder ในการต่อข้อความ (ทำงานเร็วกว่าและประหยัด Memory กว่าการบวก String ธรรมดา)
            StringBuilder resultText = new StringBuilder();

            try
            {
                // 2. ใช้ StreamReader เพื่ออ่านไฟล์ทีละบรรทัด (แก้ปัญหาโปรแกรมค้าง)
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {   
                        if (line.StartsWith("#")) continue;
                        currentLine++;

                        // เงื่อนไขที่ 1: ตัดช่วง m-n 
                        if (currentLine < m) continue;
                        if (currentLine > n) break; // เกิน n แล้วหยุดทำงานเลย ประหยัดเวลา

                        // เงื่อนไขที่ 2: กรองตามประเภทไฟล์ 
                        // สมมติว่าแยกด้วยลูกน้ำ (,) และประเภทไฟล์อยู่คอลัมน์ที่ 3 (Index = 2)
                        string[] columns = line.Split(',');
                        if (columns.Length > 6)
                        {
                            string fileType = columns[6].Trim().Trim('"');

                            if (fileType.Equals(filter, StringComparison.OrdinalIgnoreCase))
                            {
                                // ถ้าตรงเงื่อนไข ให้นำข้อความมาเก็บไว้ใน StringBuilder
                                resultText.AppendLine($"[บรรทัด {currentLine}] : {line}");
                            }
                        }
                    }
                }

                // 3. นำข้อความทั้งหมดที่คัดกรองแล้ว ไปแสดงผลที่ rtbShow
                if (resultText.Length > 0)
                {
                    rtbShow.Text = resultText.ToString();
                }
                else
                {
                    rtbShow.Text = "ไม่พบข้อมูลที่ตรงกับเงื่อนไข";
                }

                MessageBox.Show("โหลดข้อมูลสำเร็จ!", "สถานะ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Handles the Click event of the btReadCSV button, reading CSV data from the specified file and populating the
        /// DataGridView with its contents.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
		private void btReadCSV_Click(object sender, EventArgs e)
        {
            // 1. เคลียร์ข้อมูลเก่าและโครงสร้างคอลัมน์เก่าใน DataGridView ทิ้งก่อนทุกครั้ง
            dgvData.Rows.Clear();
            dgvData.Columns.Clear();

            // 2. ดึงค่า m และ n จาก TextBox บนหน้าจอ พร้อมดัก Error
            int m = 0;
            int n = 0;

            // หมายเหตุ: ถ้า TextBox บนแท็บ CSV ของคุณตั้งชื่อเป็นอย่างอื่น ให้เปลี่ยนชื่อตรง txtM และ txtN นะครับ
            if (!int.TryParse(txtM.Text, out m) || !int.TryParse(txtN.Text, out n))
            {
                MessageBox.Show("กรุณากรอกระบุช่วงบรรทัด m และ n เป็นตัวเลขให้ถูกต้อง", "ข้อมูลไม่ถูกต้อง", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (m > n)
            {
                MessageBox.Show("ค่าบรรทัดเริ่มต้น (m) ต้องไม่มากกว่าค่าบรรทัดสิ้นสุด (n)", "ข้อมูลไม่ถูกต้อง", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. ดึงค่าตัวกรองประเภทไฟล์ (File type)
            string filter = txtFilter.Text.Trim();

            string filePath = tbFileName.Text;
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                MessageBox.Show("กรุณาเลือกไฟล์ CSV ที่ต้องการเปิดก่อนครับ", "ไม่พบไฟล์", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int currentDataLine = 0; // ตัวนับบรรทัดข้อมูลจริง (ไม่นับบรรทัด #)

            try
            {
                using (StreamReader srReader = new StreamReader(filePath))
                {
                    string strLine;
                    bool bHeaderRead = false;

                    // Main loop: อ่านไฟล์ทีละบรรทัด
                    while ((strLine = srReader.ReadLine()) != null)
                    {
                        // ตรวจสอบและจัดการบรรทัดที่เป็น Comment (#)
                        if (strLine.StartsWith("#"))
                        {
                            // 🌟 แก้ไขบั๊กหัวตาราง: ดึง #HEADER มาสร้างคอลัมน์ทันทีที่เจอ และทำแค่รอบเดียว
                            if (!bHeaderRead && strLine.Length > 8 && strLine.Substring(0, 8).Equals("#HEADER"))
                            {
                                string[] strHeaders_arr = strLine.Substring(8).Split(',');
                                foreach (string strHeader in strHeaders_arr)
                                {
                                    string cleanHeader = strHeader.Trim().Trim('"');
                                    dgvData.Columns.Add(cleanHeader, cleanHeader);
                                }
                                bHeaderRead = true;
                            }
                            continue; // ข้ามบรรทัดที่เป็น Comment ไปทำงานบรรทัดถัดไป
                        }

                        // นับบรรทัดที่เป็นข้อมูลจริง
                        currentDataLine++;

                        // 🌟 ล็อกช่วงบรรทัด m และ n (ช่วยให้รองรับไฟล์ 1 ล้านเรคคอร์ดได้ โปรแกรมไม่ค้าง)
                        if (currentDataLine < m) continue;
                        if (currentDataLine > n) break; // ถ้าอ่านเกินบรรทัด n แล้ว ให้ break ออกจากลูปทันที เพื่อประหยัดเวลา

                        // ตัดแบ่งข้อมูลในแถวด้วยเครื่องหมาย Comma (,)
                        string[] strValues_arr = strLine.Split(',');

                        // ล้างเครื่องหมายคำพูดคู่ (") ออกจากข้อมูลทุกช่องเพื่อให้แสดงผลในตารางสวยงาม
                        for (int i = 0; i < strValues_arr.Length; i++)
                        {
                            strValues_arr[i] = strValues_arr[i].Trim().Trim('"');
                        }

                        // 🌟 ดึงระบบกรองประเภทไฟล์ (File type) มาใช้ร่วมด้วย (ตรวจสอบคอลัมน์ที่ 7 หรือ Index 6)
                        if (!string.IsNullOrEmpty(filter))
                        {
                            if (strValues_arr.Length > 6)
                            {
                                string fileType = strValues_arr[6];
                                // ถ้าประเภทไฟล์ไม่ตรงกับที่กรอกในช่อง File type ให้ข้ามแถวนี้ไป ไม่เอาลงตาราง
                                if (!fileType.Equals(filter, StringComparison.OrdinalIgnoreCase))
                                {
                                    continue;
                                }
                            }
                        }

                        // กรณีฉุกเฉิน: ถ้าในไฟล์ไม่มีบรรทัด #HEADER ให้สร้างคอลัมน์เริ่มต้นจากแถวข้อมูลแรกแก้ขัด
                        if (!bHeaderRead)
                        {
                            for (int i = 0; i < strValues_arr.Length; i++)
                            {
                                string defaultCol = $"Column {i + 1}";
                                dgvData.Columns.Add(defaultCol, defaultCol);
                            }
                            bHeaderRead = true;
                        }

                        // นำข้อมูลที่ผ่านการกรองทั้งหมด หยอดลงแถวของ DataGridView
                        dgvData.Rows.Add(strValues_arr);
                    }
                }

                MessageBox.Show($"โหลดข้อมูลลงตารางสำเร็จ! แสดงข้อมูลบรรทัดที่ {m} ถึง {n}", "สถานะ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการเปิดไฟล์ CSV: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Handles the Click event of the Browse button, allowing the user to select a file and displaying its path in the
        /// file name text box.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void btBrowse_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog ofd = new OpenFileDialog())
			{
				ofd.Filter = "Text Files (*.txt)|*.txt|CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
				if (ofd.ShowDialog() == DialogResult.OK)
				{
					tbFileName.Text = ofd.FileName;
				}
			}
		}


    }   // End of frmTextView class
}
