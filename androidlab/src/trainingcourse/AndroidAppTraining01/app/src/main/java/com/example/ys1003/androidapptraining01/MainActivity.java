package com.example.ys1003.androidapptraining01;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {
    public final static String EXTRA_MESSAGE = "com.example.ys1003.androidapptraining01.MESSAGE";
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    public void sendMessage(View view){
        /*
            Intent是在不同组件中(比如两个Activity)提供运行时绑定的对象。
            Intent代表一个应用"想去做什么事"，你可以用它做各种各样的任务，不过大部分的时候他们被用来启动另一个Activity。
            Intent可以携带称作 extras 的键-值对数据类型

             Intent构造函数中有两个参数：
             第一个参数是Context(之所以用this是因为当前Activity是Context的子类)
             第二个参数接受系统发送Intent的应用组件的Class（在这代码中，指将要被启动的 Activity）
         */
        EditText editText = (EditText)findViewById(R.id.edit_message);
        String message = editText.getText().toString();
        if(message.length() == 0) {
            Toast toast = Toast.makeText(getApplicationContext(),
                          "Please input the message.",
                          Toast.LENGTH_SHORT);
            toast.show();
            return;
        }
        Intent intent = new Intent(this, DisplayMessageActivity.class);
        //通过intent传递数据时，可以通过 putExtra 方法放要传递的数据
        intent.putExtra(EXTRA_MESSAGE, editText.getText().toString());
        //调用基类的 startActivity 并传入intent 来打开 intent 指定的目标 Activity.
        startActivity(intent);
    }
}
