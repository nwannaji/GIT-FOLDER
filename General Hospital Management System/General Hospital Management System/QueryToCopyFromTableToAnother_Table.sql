insert into tblPatientVitals (PatId,PatName,Height,Weight,Pressure,Temperature,PatImage) 
select  patID, pSurname+' '+pFirstname+' '+pMiddlename, Height,[Weight],Blood_Pressure,Temperature,pPhoto
from tblPatient
 where patID = '106'
               