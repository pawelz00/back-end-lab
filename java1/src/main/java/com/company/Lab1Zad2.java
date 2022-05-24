package com.company;

import java.io.FileOutputStream;
import java.util.Scanner;
public class Lab1Zad2
{
    public static void main(String args[]) {
        try{
            FileOutputStream out =new FileOutputStream("src\\testoutput.txt");
            Scanner in = new Scanner(System.in);
            String s = in.nextLine();
            byte b[]=s.getBytes();
            out.write(b);
            out.close();
            in.close();
            System.out.println("sukces!");
        }
        catch(Exception e)
        {System.out.println(e);
        }
    }
}


