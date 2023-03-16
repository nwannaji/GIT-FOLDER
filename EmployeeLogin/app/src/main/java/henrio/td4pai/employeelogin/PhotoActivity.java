package henrio.td4pai.employeelogin;

import static henrio.td4pai.employeelogin.R.*;

import android.content.Intent;
import android.graphics.Bitmap;
import android.os.Bundle;
import android.provider.MediaStore;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.RelativeLayout;
import android.widget.Toast;

import androidx.activity.result.ActivityResultLauncher;
import androidx.activity.result.contract.ActivityResultContracts;
import androidx.appcompat.app.AppCompatActivity;

public class PhotoActivity extends AppCompatActivity {
    private static final int pic_id = 100;
    private static final int REQUEST_IMAGE_CAPTURE = 1;
    Button capture,goBackButton;
    EditText registeredBy, registeredbYFroceNumber;
    ImageView pictureBox;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(layout.activity_photo);
        registeredBy = (EditText)findViewById(id.et_rOfficer);
        registeredbYFroceNumber = (EditText)findViewById(id.et_rForceNumber);
        capture = findViewById(R.id.btnSelectPhoto);
        pictureBox = findViewById(R.id.camera);
        goBackButton = (Button) findViewById(id.btn_back);

           capture.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent camera_intent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
                // Start the activity with camera_intent, and request pic id
                startActivityIfNeeded(camera_intent, pic_id);
            }
        });

           goBackButton.setOnClickListener(new View.OnClickListener() {
               @Override
               public void onClick(View v) {
                   String RegisteredByOfficer = registeredBy.getText().toString().trim();
                   String RegisteredByForceNumber = registeredbYFroceNumber.getText().toString().trim();

                   if(!(RegisteredByOfficer.isEmpty() || RegisteredByForceNumber.isEmpty())){
                       Intent intent = new Intent(PhotoActivity.this, CaptureActivity.class);
                       startActivity(intent);
                   }
                   else {
                       Toast.makeText(PhotoActivity.this, "Ops!\n Registered by officer's name and/or Force number cannot be empty.Try again", Toast.LENGTH_SHORT).show();
                   }
               }

           });
    }

    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        // Match the request 'pic id with requestCode
        if (requestCode == pic_id) {
            // BitMap is data structure of image file which store the image in memory
            Bitmap photo = (Bitmap) data.getExtras().get("data");
            // Set the image in imageview for display
            pictureBox.setImageBitmap(photo);
            RelativeLayout imageLayout = new RelativeLayout(this);

            ImageView iv = new ImageView(this);
            iv.setScaleType(ImageView.ScaleType.CENTER_CROP);
            iv.setImageResource(R.drawable.baseline_photo_camera_24);

            RelativeLayout.LayoutParams lp = new RelativeLayout.LayoutParams(LinearLayout.LayoutParams.MATCH_PARENT,LinearLayout.LayoutParams.MATCH_PARENT);
            imageLayout.addView(iv, lp);
        }
    }
}




