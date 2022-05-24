package com.company;
import java.io.IOException;

public class Lab1Zad6 {

    public static void main(String[] args) throws IOException {
        String string = "abc abcd abcde abcdef";
        String[] parts = string.split(" ");
        for (int i = 0; i < parts.length; i++) {
            System.out.println((i + 1) + "." + parts[i]);
        }

    }
}
