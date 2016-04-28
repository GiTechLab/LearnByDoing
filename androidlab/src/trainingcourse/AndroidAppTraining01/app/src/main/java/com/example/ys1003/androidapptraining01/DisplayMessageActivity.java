package com.example.ys1003.androidapptraining01;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;

/**
 * Created by YS1003 on 4/28/2016.
 */
public class DisplayMessageActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState){
        super.onCreate(savedInstanceState);
        Intent intent = getIntent();//来自源 Activity 调用 startActivity(intent); 时的传入
        String message = intent.getStringExtra(MainActivity.EXTRA_MESSAGE);
        
        //setContentView(R.layout.activity_display_message);
    }
}
