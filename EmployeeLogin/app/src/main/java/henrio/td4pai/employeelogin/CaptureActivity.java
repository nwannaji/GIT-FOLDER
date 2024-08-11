package henrio.td4pai.employeelogin;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

public class CaptureActivity extends AppCompatActivity {
    private EditText et_fname, et_sname, et_zones, et_depts, et_forceNumber, et_rank, et_station, et_sex, et_counts;
    Button saveButton, buttonPhoto,photo;
    private static    int count = 0;
    private static  int total_numberOfpolice = 350000;
    private DataBaseHelper dataBaseHelper;
    @SuppressLint("MissingInflatedId")
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_capture);
        dataBaseHelper  = new DataBaseHelper(this);

        et_fname =(EditText) findViewById(R.id.et_fname);
        et_sname =(EditText) findViewById(R.id.et_sname);
        et_zones =(EditText) findViewById(R.id.et_zones);
        et_depts =(EditText) findViewById(R.id.et_depts);
        et_forceNumber =(EditText) findViewById(R.id.et_forceNumber);
        et_rank =(EditText) findViewById(R.id.et_rank);
        et_station =(EditText) findViewById(R.id.et_station);
        et_sex =(EditText) findViewById(R.id.et_sex);
        et_counts =(EditText) findViewById(R.id.et_counts);
        saveButton =(Button) findViewById(R.id.btn_save);
        buttonPhoto = (Button) findViewById(R.id.btn_photo);
        photo = (Button) findViewById(R.id.btn_photo);

        photo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(CaptureActivity.this, PhotoActivity.class);
                startActivity(intent);
            }
        });

        do{

            count++;
        }
        while (count < total_numberOfpolice );

        saveButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
               String fname =et_fname.getText().toString().trim();
               String sname = et_sname.getText().toString().trim();
               String zones = et_zones.getText().toString().trim();
               String depts  = et_depts.getText().toString().trim();
               String fNumber = et_forceNumber.getText().toString().trim();
               String rank = et_rank.getText().toString().trim();
               String station = et_station.getText().toString().trim();
               String sex = et_sex.getText().toString().trim();
               String stringvalue = String.valueOf(count);
               et_counts.setText(stringvalue);
               String counts = et_counts.getText().toString().trim();

                if(fname.equals("")|| sname.equals("")||zones.equals("")||depts.equals("")||fNumber.equals("")
                || rank.equals("")||station.equals("")||sex.equals("")||counts.equals("")){
                    Toast.makeText(getApplicationContext(), "Fields cannot be empty or null.", Toast.LENGTH_SHORT).show();
                }
                else {
                  long check_RecordSave = dataBaseHelper.InsertNewRecord(fname,sname,zones,depts,fNumber,rank,station,sex,counts);
                  if(check_RecordSave != -1){
                      Toast.makeText(getApplicationContext(), "Record Save Successfully.", Toast.LENGTH_LONG).show();

                      et_fname.getText().clear();
                      et_sname.getText().clear();
                      et_zones.getText().clear();
                      et_depts.getText().clear();
                      et_forceNumber.getText().clear();
                      et_rank.getText().clear();
                      et_station.getText().clear();
                      et_sex.getText().clear();
                      et_counts.getText().clear();
                  }
                  else {
                      Toast.makeText(getApplicationContext(), "Record is not Saved.Try again.", Toast.LENGTH_SHORT).show();
                      et_fname.getText().clear();
                      et_sname.getText().clear();
                      et_zones.getText().clear();
                      et_depts.getText().clear();
                      et_forceNumber.getText().clear();
                      et_rank.getText().clear();
                      et_station.getText().clear();
                      et_sex.getText().clear();
                      et_counts.getText().clear();
                  }
                }
            }
        });

    }
}
