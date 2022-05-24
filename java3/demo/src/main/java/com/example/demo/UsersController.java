package com.example.demo;


import netscape.javascript.JSObject;
import org.apache.catalina.User;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;

import javax.print.attribute.standard.Media;
import java.util.List;

@Controller
public class UsersController {

    @Autowired
    public UsersService usersService;

    @RequestMapping("/api/users")
    @ResponseBody
    public UsersPage users(
            @RequestParam(name = "page-number", defaultValue = "1") Integer pageNumber,
            @RequestParam(name = "page-size", defaultValue = "20") Integer pageSize
    ) {
        return this.usersService.getUsers(pageNumber, pageSize);
    }


    @PostMapping(
            value = "/api/user/create",
            consumes = MediaType.APPLICATION_JSON_VALUE,
            produces = MediaType.APPLICATION_JSON_VALUE
    )
    @ResponseBody
    public UserEntity createUser(@RequestBody UserEntity user) {
        return this.usersService.createUser(user);
    }

    @GetMapping(
            value = "api/users/{id}",
            produces = MediaType.APPLICATION_JSON_VALUE
    )
    @ResponseBody
    public UserEntity getUser(@PathVariable int id)
    {
        return this.usersService.getUser(id);
    }

    @DeleteMapping(
            value = "api/users/{id}/remove",
            produces = MediaType.APPLICATION_JSON_VALUE
    )
    @ResponseBody
    public Boolean deleteUser(@PathVariable int id)
    {
        return this.usersService.deleteUser(id);
    }

    @PatchMapping(
            value = "api/users/{id}/update",
            consumes = MediaType.APPLICATION_JSON_VALUE,
            produces = MediaType.APPLICATION_JSON_VALUE
    )
    @ResponseBody
    public UserEntity updateUser(@RequestBody UserEntity user, @PathVariable int id)
    {
        return this.usersService.updateUser(user,id);
    }

    @RequestMapping("/api/usersArray")
    public ResponseEntity<List<UserEntity>> example() {
        if(usersService.users.size() == 0)
            return ResponseEntity.status(HttpStatus.NOT_FOUND).build();
        return ResponseEntity.status(HttpStatus.OK).body(usersService.users);
    }

}
