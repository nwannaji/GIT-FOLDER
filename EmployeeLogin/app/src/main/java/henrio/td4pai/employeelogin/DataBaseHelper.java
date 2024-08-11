package henrio.td4pai.employeelogin;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.widget.Toast;

public class DataBaseHelper extends SQLiteOpenHelper {

    public static final String DATABASE_NAME = "login.db";

    public DataBaseHelper(Context context) {
        super(context, DATABASE_NAME, null, 1);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        db.execSQL("CREATE TABLE user(ID INTEGER PRIMARY KEY AUTOINCREMENT, username TEXT, password TEXT)");
        db.execSQL("CREATE TABLE officersRecord(ID INTEGER PRIMARY KEY AUTOINCREMENT, firstname TEXT, surname TEXT," +
                "zones TEXT,dept TEXT,forceNumber TEXT, rank TEXT, station TEXT,sex TEXT,counts TEXT)");
        db.execSQL("CREATE UNIQUE INDEX forceNumber_index ON officersRecord(forceNumber)");
        db.execSQL("ALTER TABLE officersRecord ADD COLUMN image BLOB");
        db.execSQL("ALTER TABLE officersRecord ADD COLUMN registeredBy TEXT");
        db.execSQL("ALTER TABLE officersRecord ADD COLUMN registeredBy_forceNumber TEXT");
    }
    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        db.execSQL("DROP TABLE IF EXISTS user");
        db.execSQL("DROP TABLE IF EXISTS officersRecord");
         onCreate(db);
    }
    public  boolean Insert(String username, String password){
  SQLiteDatabase db = this.getWritableDatabase();
        ContentValues cv = new ContentValues();
        cv.put("username",username);
        cv.put("password",password);
long result = db.insert("user",null,cv);
if(result == -1){
    return  false;
}else {
    return  true;
  }
}

public boolean checkUsername(String username){
        SQLiteDatabase db = this.getWritableDatabase();
    Cursor cursor = db.rawQuery("SELECT * FROM user WHERE username=?", new String[]{username});
    if(cursor.getCount() > 0){
        return  false;
    }else {
        return  true;
    }
}
public  boolean checkLogin(String username, String password){
        SQLiteDatabase db = this.getWritableDatabase();
        Cursor cursor = db.rawQuery("SELECT * FROM user WHERE username=? AND password=?", new String[]{username,password});
        if(cursor.getCount() > 0){
            return  true;
        } else{
            return  false;
        }
}

public long InsertNewRecord(String firstname, String surname,String zones,String depts,String forceNumber,String rank,
                              String station,String gender,String counts){
        SQLiteDatabase db = this.getWritableDatabase();
       ContentValues cv = new ContentValues();
       cv.put("firstname",firstname);
       cv.put("surname",surname);
       cv.put("zones",zones);
       cv.put("dept",depts);
       cv.put("forceNumber",forceNumber);
       cv.put("rank",rank);
       cv.put("station",station);
       cv.put("sex",gender);
       cv.put("counts",counts);

       long con = db.insert("officersRecord",null,cv);
       return  con;


}
}
