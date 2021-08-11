using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace General_Hospital_Management_System
{
    public partial class frmParent : Form
    {
        ClsSelect select = new ClsSelect();
        ClsUpdate theUpdates = new ClsUpdate();


        public frmParent()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = new DateTime();
            dt = DateTime.Now;
            getDate.Text = dt.Date.ToLongDateString();
            workinTime.Text = dt.Hour + ":" + dt.Minute + ":" + dt.Second;
            string.Format("{0:0.00}",workinTime);
        }

        private void frmParent_Load(object sender, EventArgs e)
        {
            select = new ClsSelect();
            timer1.Start();
        }
        private void frmParent_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmLogin fm = new frmLogin();
            fm.Show();
            //Application.Exit();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployee employee = new frmEmployee();
            employee.Show();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsers _users = new frmUsers();
            _users.Show();
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSupplier supplier = new frmSupplier();
            supplier.Show();
        }

        private void productSalesInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProduct product = new frmProduct();
            product.empName = this.getEmpCodes.Text;
            product.Show();
        }

        private void checkupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmPatientVitals fpv = new frmPatientVitals();
            //fpv.Show();
            
        }

        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPayments payment = new frmPayments();
            payment.cashierName = this.getEmpCodes.Text;
        }

        private void appointmentToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FrmAppointment appointment = new FrmAppointment();
            appointment.Show();
        }

        private void consultationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultation frm = new frmConsultation();
            frm.tbDocName.Text = this.getEmpCodes.Text;
            frm.Show();
        }

        private void updatePasswordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmUpdatePassword update = new frmUpdatePassword();
            update.Show();
        }

        private void updatePasswordToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmUpdatePassword update = new frmUpdatePassword();
            update.Show();
        }

        private void updatePasswordToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmUpdatePassword update = new frmUpdatePassword();
            update.Show();
        }

        private void updatePasswordToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmUpdatePassword update = new frmUpdatePassword();
            update.Show();
        }

        private void viewAppointmentToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmViewAppointment viewApp = new frmViewAppointment();
            viewApp.Show();
        }

        private void viewAppointmentToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmViewAppointment viewApp = new frmViewAppointment();
            viewApp.Show();
        }

        private void addAppointmentToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmAppointment appointment = new FrmAppointment();
            appointment.Show();
        }

        private void viewAppointmentToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmViewAppointment viewApp = new frmViewAppointment();
            viewApp.Show();
        }

        private void addAppointmentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmAppointment appointment = new FrmAppointment();
            appointment.Show();
        }

        private void viewAppointmentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmViewAppointment viewApp = new frmViewAppointment();
            viewApp.Show();
        }

        private void addAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAppointment appointment = new FrmAppointment();
            appointment.Show();
        }

        private void viewAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViewAppointment viewApp = new frmViewAppointment();
            viewApp.Show();
        }

        private void viewPatientToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmViewPatient viewPat = new frmViewPatient();
            viewPat.Show();
        }

        private void viewPatientWeightToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //frmViewPatientWeight viewWeight = new frmViewPatientWeight();
            frmPatientVitals vitals = new frmPatientVitals();
            vitals.Show();
        }

        private void addPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPatient patient = new frmPatient();
            patient.nurseName = this.getEmpCodes.Text;
            patient.Show();
        }

        private void viewPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViewPatient viewPat = new frmViewPatient();
            viewPat.Show();
        }

        private void viewPatientWeightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // frmViewPatientWeight viewWeight = new frmViewPatientWeight();
            frmPatientVitals vitals = new frmPatientVitals();
            vitals.Show();
        }

        private void updatePatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdatePatient _updatePatient = new frmUpdatePatient();
            _updatePatient.Show();
        }

        private void updateEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateEmployee _updateEmployee = new frmUpdateEmployee();
            _updateEmployee.Show();
        }

        private void viewEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViewEmployee viewEmployee = new frmViewEmployee();
            viewEmployee.Show();
        }

        private void viewUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViewUsers viewUsers = new frmViewUsers();
            viewUsers.Show();

        }

        private void viewDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViewDept deptView = new frmViewDept();
            deptView.Show();
        }

        private void updatePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdatePassword update = new frmUpdatePassword();
            update.Show();
        }

        private void nowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            theUpdates.Backup();
        }

        

        private void departmentTooStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddNewDepartment addDept = new FrmAddNewDepartment();
            addDept.Show();
        }

        private void appointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAppointment appointment = new FrmAppointment();
            appointment.Show();
        }

        private void addAppointmentToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmAppointment appointment = new FrmAppointment();
            appointment.Show();
        }

        private void viewAppointmentToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmViewAppointment viewAppoint = new frmViewAppointment();
            viewAppoint.Show();
        }

        private void addDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddNewDepartment new_dept = new FrmAddNewDepartment();
            new_dept.Show();
        }

        private void viewDepartmentToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmViewDept view_dept = new frmViewDept();
            view_dept.Show();
        }

        private void updatePasswordToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmUpdatePassword upassword = new frmUpdatePassword();
            upassword.Show();
        }

        private void viewUsersToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmViewUsers view_Users = new frmViewUsers();
            view_Users.Show();
        }

        private void updateEmployeeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmUpdateEmployee updateEmployee = new frmUpdateEmployee();
            updateEmployee.Show();
        }

        private void viewEmployeeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmViewEmployee employee = new frmViewEmployee();
            employee.Show();
        }

        private void addAppointmentToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
           FrmAppointment appointment = new FrmAppointment();
            appointment.Show();
        }

        private void viewAppointmentToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            frmViewAppointment vappointment = new frmViewAppointment();
            vappointment.Show();
        }

        private void viewTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDailyTransaction vTransact = new frmDailyTransaction();
            vTransact.Show();
        }

        private void viewBillsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPatientBills pBill = new frmPatientBills();
            pBill.Show();
        }

        private void viewItemBillingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViewBills bills = new frmViewBills();
            bills.Show();
        }

       

        private void consultant1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void consultant2ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void consultant3ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewPatientBMIToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void checkHeightToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void calculateBMIToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void checkBloodPressureToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewPtientBloodPressureToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void medicalSupplyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void equipmentSupplyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void maleWardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWard fmward = new frmWard();
            fmward.Show();
        }

        private void femaleWardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWard fmward = new frmWard();
            fmward.Show();
        }

        private void generalWardToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gOPDWardToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MaleWard1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void maleWard2ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void maleWard3ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewAppointmentToolStripMenuItem4_Click_1(object sender, EventArgs e)
        {
            frmViewAppointment view = new frmViewAppointment();
            view.Show();
        }

        private void bookAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAppointment appoint = new FrmAppointment();
            appoint.Show();
        }

        private void doctorsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void transactionToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmPayments payment = new frmPayments();
            payment.cashierName = this.getEmpCodes.Text;
            payment.Show();
        }

        private void supportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHelp _help = new frmHelp();
            _help.Show();
        }

        private void updatePatientToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmUpdatePatient upd = new frmUpdatePatient();
            upd.Show();
        }

        private void malewardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmMaleWard frmward = new frmMaleWard();
            frmward.Show();
        }

        private void femalewardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmFemaleWard fmward = new frmFemaleWard();
            fmward.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
