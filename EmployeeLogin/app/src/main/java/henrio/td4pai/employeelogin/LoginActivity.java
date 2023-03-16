package henrio.td4pai.employeelogin;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class LoginActivity extends AppCompatActivity {
    private Button registerButton, loginButton;
    private EditText et_username, et_password;
    private DataBaseHelper dataBaseHelper;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        dataBaseHelper = new DataBaseHelper(this);

        et_username = (EditText)findViewById(R.id.et_username);
        et_password = (EditText)findViewById(R.id.et_password);

        loginButton = (Button)findViewById(R.id.btn_login);
        registerButton = (Button)findViewById(R.id.btn_register);

       registerButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(LoginActivity.this, MainActivity.class);
                startActivity(intent);
                finish();
            }
        });

  loginButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String username = et_username.getText().toString().trim();
                String password = et_password.getText().toString().trim();
                if(username.isEmpty() || password.isEmpty()){
                    Toast.makeText(getApplicationContext(), "Username or Password cannot be empty! Try again.", Toast.LENGTH_SHORT).show();
                }
                else {
                    boolean check_login = dataBaseHelper.checkLogin(username,password);
                    if(check_login == true){
                        Toast.makeText(getApplicationContext(),"Login Successful.",Toast.LENGTH_SHORT).show();
                        et_username.getText().clear();
                        et_password.getText().clear();

                        Intent intent = new Intent(LoginActivity.this, CaptureActivity.class);
                        startActivity(intent);
                        finish();
                    }
                    else{
                        Toast.makeText(getApplicationContext(), "Invalid Username or Password.", Toast.LENGTH_SHORT).show();
                        et_username.getText().clear();
                        et_password.getText().clear();
                    }
                }
            }
        });
    }

}