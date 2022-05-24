package com.company;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

public class Lab1Zad1 {

    public static void main(String[] args) throws IOException {
        File file = new File("test.txt");

        if(!file.exists())
        {
            file.createNewFile();
        }

        FileInputStream fis = new FileInputStream(file);

        int i = fis.read();

        while(!(i==-1)) {
            char c = (char)i;
            System.out.print(c);
            i= fis.read();
        }
        fis.close();
    }

}
