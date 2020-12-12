package com.example.coffeapp;

import android.app.Activity;
import android.app.ProgressDialog;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.preference.PreferenceManager;
import android.text.TextUtils;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import androidx.annotation.Nullable;

import com.android.volley.AuthFailureError;
import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

import static android.content.ContentValues.TAG;

public class LoginActivity extends Activity {
    private String url = Connection.url;

    EditText ETUsername,ETPassword;
    Button BTNLogin;
    String password = new String();
    String passwordHash= new String();
    public static ArrayList<Profile> profiles = new ArrayList<>();


    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        SharedPreferences preferences = PreferenceManager.getDefaultSharedPreferences(this);
        boolean finish = preferences.getBoolean("finish", false);
        if (finish) {
            startActivity(new Intent(getApplicationContext(), HomeActivity.class));
            finish();
            return;
        }else{

        }
        ETUsername = findViewById(R.id.idUsernameLogin);
        ETPassword = findViewById(R.id.idPasswordLogin);
        BTNLogin = findViewById(R.id.idSignInLogin);
        password = ETPassword.getText().toString();


        getProfiles();


        BTNLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                validte();
            }
        });
    }

    private void getProfiles() {
        StringRequest request = new StringRequest(Request.Method.POST, url+"users.php", new Response.Listener<String>() {
            @Override
            public void onResponse(String response) {
                profiles.clear();
                try {

                    JSONObject jsonObject = new JSONObject(response);
                    String succes = jsonObject.getString("succes");
                    JSONArray jsonArray = jsonObject.getJSONArray("users");

                    if (succes.equals("1")) {

                        for (int i = 0; i < jsonArray.length(); i++) {

                            JSONObject object = jsonArray.getJSONObject(i);
                            String id = object.getString("id");
                            String first_name = object.getString("first_name");
                            String last_name = object.getString("last_name");
                            String username = object.getString("username");
                            String pin_code  = object.getString("pin_code");
                            String password = object.getString("password_hash");
                            String telephone_number = object.getString("telephone_number");
                            //Log.i(TAG, id+"-"+username);


                            profiles.add(new Profile(id,first_name,last_name,username,password,telephone_number,pin_code));
                            //   Log.i(TAG, ""+profiles.size());
                            //   Log.i(TAG, ".    "+username);

                        }
                    }
                } catch (JSONException e) {
                    Log.i(TAG, e.getMessage());
                    //  Toast.makeText(applicationContext,e.getMessage(),Toast.LENGTH_LONG).show();
                }
            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                Toast.makeText(LoginActivity.this, error.getMessage(), Toast.LENGTH_SHORT).show();
                Log.i(TAG, error.getMessage());
            }
        });

        RequestQueue requestQueue = Volley.newRequestQueue(this);
        requestQueue.add(request);
    }

    private void validte() {
        final String username = ETUsername.getText().toString().trim();
        final String password = ETPassword.getText().toString().trim();

        if (TextUtils.isEmpty(username)) {
            ETUsername.setError("Ju lutem shkurani perdoruesin!");
            ETUsername.requestFocus();
            return;
        }

        if (TextUtils.isEmpty(password)) {
            ETPassword.setError("Ju lutem shkruani fjalkalimin!");
            ETPassword.requestFocus();
            return;
        }

        String welcome = null;
        boolean match = false;
        try {
            hashPassword();
        } catch (NoSuchAlgorithmException e) {
            e.printStackTrace();
        }

        Intent intent = new Intent(LoginActivity.this,HomeActivity.class);
        if (profiles.size() > 0) {
            for (int i = 0; i < profiles.size(); i++) {
                  Log.e("@",profiles.get(i).getUsername()+"-pw:-"+profiles.get(i).getPassword());
                 Log.e("#",ETUsername.getText().toString()+"-baba:-"+passwordHash);
                if (ETUsername.getText().toString().trim().equals(profiles.get(i).getUsername().trim()) && passwordHash.trim().equals(profiles.get(i).getPassword().trim())) {
                    match = true;
                    SharedPreferences sharedPreferences = PreferenceManager
                            .getDefaultSharedPreferences(this);
                    SharedPreferences.Editor editor = sharedPreferences.edit();
                    editor.putString("id", profiles.get(i).getId());
                    editor.putString("first_name", profiles.get(i).getFirst_name());
                    welcome = profiles.get(i).getFirst_name();
                    editor.putString("last_name", profiles.get(i).getLast_name());
                    editor.putString("username", username);
                    editor.putString("password", passwordHash);
                    editor.putString("telephone_number", profiles.get(i).getTelephone_number());
                    editor.putBoolean("finish", true);
                    editor.apply();
                    intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                    intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                    intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                    startActivity(intent);
                }
                if (match == true){
                    Toast.makeText(getApplicationContext(), "Miresevini "+welcome,Toast.LENGTH_SHORT).show();
                } else{
                //    Toast.makeText(getApplication(), "Perdoruesi ose fjalekalimi gabim!", Toast.LENGTH_SHORT).show();
                }
            }
        }
    }

    private void hashPassword() throws NoSuchAlgorithmException {
        final String MD5 = "MD5";
        try {
            // Create MD5 Hash
            MessageDigest digest = java.security.MessageDigest
                    .getInstance(MD5);
            digest.update(ETPassword.getText().toString().getBytes());
            byte messageDigest[] = digest.digest();

            // Create Hex String
            StringBuilder hexString = new StringBuilder();
            for (byte aMessageDigest : messageDigest) {
                String h = Integer.toHexString(0xFF & aMessageDigest);
                while (h.length() < 2)
                    h = "0" + h;
                hexString.append(h);
            }
            passwordHash = hexString.toString();

        } catch (NoSuchAlgorithmException e) {
            e.printStackTrace();
        }
    }


}
