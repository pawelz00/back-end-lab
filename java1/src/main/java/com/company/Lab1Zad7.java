//package com.company;
//import java.io.IOException;
//import com.fasterxml.jackson.core.JsonProcessingException;
//import com.fasterxml.jackson.databind.ObjectMapper;
//
//public class Lab1Zad7 {
//
//    public static void main(String[] args) throws JsonProcessingException {
//        ObjectMapper objectMapper = new ObjectMapper();
//
//        User userObject = new User("John", 21);
//        String userJson = objectMapper.writeValueAsString(userObject);
//
//        System.out.println(userJson); // {"name":"John","age":21}
//
//    }
//}