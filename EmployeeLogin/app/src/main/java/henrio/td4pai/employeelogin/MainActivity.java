package henrio.td4pai.employeelogin;

import androidx.appcompat.app.AppCompatActivity;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.RelativeLayout;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {
 private DataBaseHelper dataBaseHelper;
 private EditText et_Username,et_password,et_cpassword;
 private Button registerButton,loginButton;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        dataBaseHelper = new DataBaseHelper(this);
        et_Username = (EditText)findViewById(R.id.et_Username);
        et_password = (EditText)findViewById(R.id.et_password);
        et_cpassword = (EditText)findViewById(R.id.et_cpassword);
        registerButton= (Button) findViewById(R.id.btn_register);
        loginButton = (Button)findViewById(R.id.btn_login);

      loginButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
             Intent intent = new Intent(MainActivity.this, LoginActivity.class);
             startActivity(intent);
            }
        });

    registerButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String username = et_Username.getText().toString().trim();
                String password = et_password.getText().toString().trim();
                String confirm_password = et_cpassword.getText().toString().trim();

                if(username.isEmpty()|| password.isEmpty()||confirm_password.isEmpty()){
                    Toast.makeText(getApplicationContext(),"Fields required",Toast.LENGTH_SHORT).show();
                }
                else {
                    if(password.equals(confirm_password)){
                        boolean check_username = dataBaseHelper.checkUsername(username);
                        if(check_username ==true){
                            boolean insert = dataBaseHelper.Insert(username,password);
                            if(insert ==true){
                                Toast.makeText(getApplicationContext(),"User Registered.",Toast.LENGTH_LONG).show();
                                et_Username.getText().clear();
                                et_password.getText().clear();
                                et_cpassword.getText().clear();
                            }else {
                                Toast.makeText(getApplicationContext(),"Username Already Exist",Toast.LENGTH_LONG).show();
                            }
                        }else {
                            Toast.makeText(getApplicationContext(), "Password does not match!", Toast.LENGTH_SHORT).show();
                        }
                    }
                }

            }
        });
    }
}