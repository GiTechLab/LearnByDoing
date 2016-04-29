package com.example.ys1003.androidapptraining01;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.TextView;

public class DisplayMessageActivity extends AppCompatActivity {

    /*
    * 注意：在此界面上点击左上角的返回按钮与点击左下角的系统自带的返回按钮虽然都返回
    * MainActivity, 但呈现的结果和背后的原理是不一样的.
    * */

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_display_message);

        //设置界面的内容要在设定页面布局之后
        Intent intent = getIntent();//来自源 Activity 调用 startActivity(intent); 时的传入
        String message = intent.getStringExtra(MainActivity.EXTRA_MESSAGE);
        TextView textView = (TextView)findViewById(R.id.label_message);
        textView.setText(message);
    }
}
