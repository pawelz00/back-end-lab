package com.company;

import java.io.IOException;
import java.util.*;

public class Dodatkowe {
    public static void main(String[] args) throws IOException {
        //1
       ArrayList<String> stringList = new ArrayList<String>();
       LinkedList<String> stringLinkedList = new LinkedList<>();

       stringList.add("Volvo"); stringList.add("BMW"); stringList.add("Ford"); stringList.add("Porsche");
       stringLinkedList.add("A"); stringLinkedList.add("B"); stringLinkedList.add("C");
       stringLinkedList.add("D"); stringLinkedList.add("D"); stringLinkedList.add("D");

        ListIterator<String> stringListIterator = stringList.listIterator();
        ListIterator<String> stringListIterator2 = stringLinkedList.listIterator();
        while(stringListIterator.hasNext()){
            System.out.println(stringListIterator.next());
            stringListIterator.next();
            stringListIterator.remove();
        }
        while(stringListIterator2.hasNext()){
            System.out.println(stringListIterator2.next());
            stringListIterator2.next();
            stringListIterator2.remove();
        }

        //2
        HashSet<String> set = new HashSet<String>(stringList);
        ArrayList<String>stringListNoDuplicates = new ArrayList<>(set);

        //3
        HashMap<String, Integer> hm = convertArrayListToHashMap(stringList);
        System.out.println(hm.size()); // 2 -> ponieważ usunęliśmy dwie pozycje przy pomocy iteratora
    }

    //Metoda konwersji dla wygody
    private static HashMap<String, Integer>
    convertArrayListToHashMap(ArrayList<String> arrayList)
    {

        HashMap<String, Integer> hashMap = new HashMap<>();

        for (String str : arrayList) {

            hashMap.put(str, str.length());
        }

        return hashMap;
    }
}
