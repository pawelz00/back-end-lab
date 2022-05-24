package com.example.demo.controllers;

import com.example.demo.requests.UserLoginRequest;
import com.example.demo.requests.UserRegisterRequest;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Service;

import javax.mail.MessagingException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpSession;

@Service
public class AuthenticationService {

    @Autowired
    private MailService mailService;
    @Value("${admin.username}")
    private String adminUsername;
    @Value("${admin.password}")
    private String adminPassword;
    @Value("${admin.email}")
    private String adminEmail;

    public boolean checkUser(HttpServletRequest request)
    {
        HttpSession session = request.getSession();
        Long loggedUserId = (Long)session.getAttribute("logged-user-id");
        return loggedUserId != null;
    }

    public boolean registerUser(UserRegisterRequest userRegisterRequest) throws MessagingException {
        this.mailService.sendEmail("mail@mail.com", "Welcome","Wiadomosc");
         return true;
    }
    public boolean loginUser(UserLoginRequest userLoginRequest, HttpServletRequest request)
    {
        //odczyt z bazy
        HttpSession session = request.getSession();
        if ((this.adminUsername.equals(userLoginRequest.getIdentifier())
            || this.adminEmail.equals(userLoginRequest.getIdentifier()))
            && this.adminPassword.equals(userLoginRequest.getPassword())
            ) {
            session.setAttribute("logged-user-id", 1000L); //root id
            return true;
        }
        return true;
    }

    public boolean logoutUser(HttpServletRequest request)
    {
        HttpSession session = request.getSession();
        session.removeAttribute("logged-user-id");
        return true;
    }
}
