package com.company;

import java.time.LocalTime;
import java.util.Date;
import java.util.TimeZone;

public class Lab1Zad5 {

    public static void main(String[] args) {
        LocalTime localtime = LocalTime.now();
        System.out.println(localtime);
        Date now = new Date();
        TimeZone.setDefault(TimeZone.getTimeZone("GMT"));
        System.out.println(now);
    }

}