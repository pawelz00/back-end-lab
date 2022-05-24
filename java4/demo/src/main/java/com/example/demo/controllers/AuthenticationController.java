package com.example.demo.controllers;

import com.example.demo.requests.UserLoginRequest;
import com.example.demo.requests.UserRegisterRequest;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.http.MediaType;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;

import javax.mail.MessagingException;
import javax.print.attribute.standard.Media;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpSession;

@Controller
public class AuthenticationController {

    @Autowired
    private AuthenticationService authenticationService;

    @RequestMapping(
            value = "api/user/register",
            method = RequestMethod.POST,
            consumes = MediaType.APPLICATION_JSON_VALUE
    )
    @ResponseBody
    public String register(
            HttpServletRequest request,
            @RequestBody UserRegisterRequest userRegisterRequest
    ){
        if(this.authenticationService.checkUser((request)))
            return "Failed, user already logged in";
        try {
            if(this.authenticationService.registerUser(userRegisterRequest))
                return "Success";
        } catch (MessagingException e) {
            e.printStackTrace();
            return "Fail";
        }
        return "Fail";
    }

    @RequestMapping(
            value = "api/user/login",
            method = RequestMethod.POST,
            consumes = MediaType.APPLICATION_JSON_VALUE
    )
    @ResponseBody
    public String login(
            HttpServletRequest request,
            @RequestBody UserLoginRequest userLoginRequest
    ) {
        if(this.authenticationService.checkUser(request))
            return "Failed, user already logged in";

        if(this.authenticationService.loginUser(userLoginRequest, request))
            return "Success";

        return "Fail";
    }

    @GetMapping(
            value = "api/user/check",
            produces = MediaType.APPLICATION_JSON_VALUE
    )
    @ResponseBody
    public String checkUser(
            HttpServletRequest request
    ){
        if(this.authenticationService.checkUser(request))
            return "User logged in";
        return "User not logged in";
    }


    @GetMapping(
            value = "api/user/logout",
            consumes = MediaType.APPLICATION_JSON_VALUE
    )
    @ResponseBody
    public String logoutUser(
            HttpServletRequest request
    ) {
        if(this.authenticationService.logoutUser(request))
            return "Użytkownik wylogowany";
        return "Fail";
    }

}
