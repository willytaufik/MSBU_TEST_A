# MSBU_TEST_A
# Dashboard Form Produk Net Core Framework 7\
Cara Menggunakan Aplikasi\
1.Buat database manual dengan struktur sebagai berikut\
CREATE TABLE produk (\
    id INT PRIMARY KEY IDENTITY(1,1),\
    nama_barang VARCHAR(200) NOT NULL,\
    kode_barang VARCHAR(50) NOT NULL,\
    jumlah_barang INT NOT NULL,\
    tanggal DATETIME NOT NULL\
);\
buat store procedure\
a.add\
![image](https://github.com/willytaufik/MSBU_TEST_A/assets/7637864/975b7755-7b13-4c8f-b052-480b81065021)\

b.Edit\
![image](https://github.com/willytaufik/MSBU_TEST_A/assets/7637864/ccbf2b85-c53d-44d0-b136-d6b339662930)\

c.Delete\
![image](https://github.com/willytaufik/MSBU_TEST_A/assets/7637864/01b3468d-0a97-4a3e-8cb3-04b6ed434588)\

d.Search\
![image](https://github.com/willytaufik/MSBU_TEST_A/assets/7637864/269aed50-94d5-42f1-8041-69bc3a440b67)\

2.atau impor database yang berada di folder database\
3.clone project \
4.buka project dengan tools IDE anda ( disini saya pakai vs code )\
5.pada terminal jalankan command " dotnet run" (tanpa tanda petik)\
![image](https://github.com/willytaufik/MSBU_TEST_A/assets/7637864/6d055b1a-3f92-4559-92b3-90344bf4300a)\

# Screenshoot
1.halaman Index\
![image](https://github.com/willytaufik/MSBU_TEST_A/assets/7637864/d7d911f6-2268-4981-8dc8-c473affdf537)\

2.Halaman Produk\
  a. halaman Pencarian\
  ![image](https://github.com/willytaufik/MSBU_TEST_A/assets/7637864/0d9f2fb9-21b2-4644-bc32-ca7c3aef7ef1)\
  b. halaman Tambah 
  ![image](https://github.com/willytaufik/MSBU_TEST_A/assets/7637864/1476dea4-52e5-47c1-a9e5-7f32f45d5a69)\
  c. halaman Ubah\
  ![image](https://github.com/willytaufik/MSBU_TEST_A/assets/7637864/97f610fb-7664-4add-9a98-04e320482153)






