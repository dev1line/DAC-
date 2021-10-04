select * from 
(select Danhsachnhanvien.ID, Danhsachnhanvien.Name[Tên nhân viên], Danhsachnhom.Nhom[Nhóm],Danhsachnhanvien.ChungChi[Chứng chỉ] from Danhsachnhanvien INNER JOIN Danhsachnhom ON Danhsachnhanvien.NhomID = Danhsachnhom.ID  WHERE Danhsachnhanvien.Ngayhethanchungchi > N'211004') as a left  join 
(select Ten from Danhsachnhanvien as b1 inner join lichLV as b2 on b1.Name = b2.Ten  WHERE b2.Ngay = N'211004' ) as b
on a.[Tên nhân viên] = b.Ten 
left join
 (select QLNgayNghi.NV,QLNgayNghi.Ngay from QLNgayNghi where Ngay = N'211004') as d
 on a.ID = d.NV
where Ten is null and d.Ngay is null

select * from 
( select ID, Chungchi[Chứng chỉ],Ten[Tên nhân viên] from lichLV where Ngay = N'211004') as c  left join
( select CCNV,NV from lichWO where Ngay = N'211004') as d
 on c.[Tên nhân viên] = d.NV where NV is null

 use Quanlynhanvien
 create table QLNgayNghi (
	ID int identity primary key,
	NV int not null,
	Ngay date,
	foreign key (NV) references Danhsachnhanvien(ID)
 )

 insert into QLNgayNghi (NV, Ngay) values(6,N'211004')
 insert into QLNgayNghi (NV, Ngay) values(24,N'211004')

 select c.ID, c.[Tên nhân viên],c.[Chứng chỉ] , d.Ngay from 
  (select Danhsachnhanvien.ID, Danhsachnhanvien.Name[Tên nhân viên],Danhsachnhanvien.ChungChi[Chứng chỉ] from Danhsachnhanvien 
  WHERE Danhsachnhanvien.Ngayhethanchungchi > N'211004' ) as c left join
 (select QLNgayNghi.NV,QLNgayNghi.Ngay from QLNgayNghi where Ngay = N'211004') as d
 on c.ID = d.NV where Ngay is null
