//package com.company;
//import com.fasterxml.jackson.core.JsonProcessingException;
//import com.fasterxml.jackson.databind.ObjectMapper;
//public class Lab1Zad8 {
//    public static void main(String[] args) throws JsonProcessingException {
//        ObjectMapper objectMapper = new ObjectMapper();
//
//        String userJson = "{\"name\":\"John\",\"age\":21}";              // {"name":"John","age":21}
//        User userObject = objectMapper.readValue(userJson, User.class);
//
//        System.out.println(userObject.getName());                        // John
//        System.out.println(userObject.getAge());                         // 21
//    }
//}
