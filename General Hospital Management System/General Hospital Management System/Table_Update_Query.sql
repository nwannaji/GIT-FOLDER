
ALTER TABLE tblEmployees
ADD CONSTRAINT FK_tblEmployees_tblEmployees FOREIGN KEY(empDept)
REFERENCES tblDepartment (deptName)
ON DELETE CASCADE
ON UPDATE CASCADE