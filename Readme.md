# HW4 - FileProcessing (MalwareBazaar Data Loader)

แอปพลิเคชัน Windows Forms (C#) สำหรับการโหลด อ่าน และคัดกรองข้อมูลจากไฟล์ CSV ขนาดใหญ่ (`MalwareBazaar.csv`) ได้อย่างมีประสิทธิภาพ โดยตัวโปรแกรมถูกออกแบบมาให้ทำงานได้อย่างรวดเร็วและ **"ไม่มีการ Crash"** แม้จะเปิดไฟล์ที่มีข้อมูลมากกว่า 1 ล้านแถวก็ตาม

## 🌟 ฟีเจอร์หลัก (Features)
* **Partial Loading (m - n):** สามารถระบุช่วงบรรทัดเริ่มต้น ($m$) และบรรทัดสิ้นสุด ($n$) ที่ต้องการอ่านได้ ช่วยให้ไม่ต้องโหลดไฟล์ทั้งหมดเข้าสู่ Memory รวดเดียว
* **Data Filtering:** รองรับการคัดกรองข้อมูลตามประเภทไฟล์ (เช่น exe, dll, docx) จาก Dataset
* **Memory Optimization:** เลือกใช้ `StreamReader` ในการอ่านไฟล์ทีละบรรทัด ร่วมกับ `StringBuilder` ในการจัดการข้อความ ทำให้ประมวลผลไฟล์ขนาดใหญ่ (Big Data) ได้อย่างราบรื่นและใช้ทรัพยากรเครื่องน้อยที่สุด

## 🛠️ เทคโนโลยีที่ใช้ (Technologies)
* **Language:** C#
* **Framework:** .NET Windows Forms Application
* **Concepts:** Stream I/O (`StreamReader`), Text Optimization (`StringBuilder`), Defensive Programming

## 🚀 วิธีการติดตั้งและรันโปรแกรม (How to Run)
1. ทำการ Clone Repository นี้ลงไปที่เครื่องของคุณ:
   ```bash
   git clone [https://github.com/Phisalphanumass/HW4-FileProcessing.git](https://github.com/Phisalphanumass/HW4-FileProcessing.git)
