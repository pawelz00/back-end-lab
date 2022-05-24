package com.example.demo;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;
import org.apache.commons.io.FileUtils;
import org.springframework.stereotype.Service;

import javax.annotation.PostConstruct;
import javax.annotation.PreDestroy;
import java.io.File;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

@Service
public class UsersService {

    public List<UserEntity> users = new ArrayList<>();
    File json = new File("C:\\Users\\pawet\\IdeaProjects\\java3\\demo\\src\\main\\resources\\users.json");
    ObjectMapper mapper = new ObjectMapper();

//    @PostConstruct
//    private void onConstruct() {
//        this.users.add(0,new UserEntity(0, "Jan Kowalski", "jankowalski@e.com"));
//    }

    @PostConstruct
    private void onCreate() throws IOException {
        String exampleRequest = FileUtils.readFileToString(json, StandardCharsets.UTF_8);
        users = mapper.readValue(exampleRequest, new TypeReference<List<UserEntity>>(){});
    }

    @PreDestroy
    private void onDestroy() throws IOException {
        mapper.writeValue(json,users);
    }


    public UsersPage getUsers(int pagenumber, int pagesize) {

        pagenumber = Math.max(1, pagenumber);
        pagesize = Math.max(1, pagesize);
        pagesize = Math.min(100, pagesize);

        int totalCount = users.size();
        int pagesCount = (totalCount/pagesize) + 1;

        return new UsersPage(pagenumber, pagesCount, pagesize, totalCount, users);
    }

    public UserEntity createUser(UserEntity user)
    {
        int id = users.size();
        String name = user.name;
        String email = user.email;
        this.users.add(new UserEntity(id,name,email));
        return this.users.get(id);
    }

    public UserEntity getUser(int id)
    {
        if(id < users.size())
             return users.get(id);
        else {
            return null;
        }
    }
    public Boolean deleteUser(int id)
    {
        users.remove(users.get(id));
        if(users.contains(users.get(id)))
            return true;
        else
            return false;
    }

    public UserEntity updateUser(UserEntity user,int id)
    {
        UserEntity _user = users.get(id);
        _user.name = user.name;
        _user.email = user.email;
        users.remove(_user);
        users.add(_user);
        return user;
    }
}
