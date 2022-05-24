package com.example.demo;

import java.util.ArrayList;
import java.util.List;

public class UsersPage {
    private int pageNumber;
    private int pagesCount;
    private int pageSize;
    private int totalCount;
    private List<UserEntity> users;


    public UsersPage(int pageNumber, int pagesCount, int pageSize, int totalCount, List<UserEntity> users) {
        this.pageNumber = pageNumber;
        this.pagesCount = pagesCount;
        this.pageSize = pageSize;
        this.totalCount = totalCount;
        this.users = users;
    }

    public void setPageNumber(int pageNumber) {
        this.pageNumber = pageNumber;
    }

    public void setPagesCount(int pagesCount) {
        this.pagesCount = pagesCount;
    }

    public void setPageSize(int pageSize) {
        this.pageSize = pageSize;
    }

    public void setTotalCount(int totalCount) {
        this.totalCount = totalCount;
    }

    public void setUsers(List<UserEntity> users) {
        this.users = users;
    }

    public int getPageNumber() {
        return pageNumber;
    }

    public int getPagesCount() {
        return pagesCount;
    }

    public int getPageSize() {
        return pageSize;
    }

    public int getTotalCount() {
        return totalCount;
    }

    public List<UserEntity> getUsers() {
        return users;
    }
}


