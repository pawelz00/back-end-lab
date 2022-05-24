package com.example.demo.requests;

public class UserLoginRequest {

	private String identifier;
	private String password;

	public UserLoginRequest(String identifier, String password) {
		this.identifier = identifier;
		this.password = password;
	}

	public UserLoginRequest() {
	}

	public String getIdentifier() {
		return identifier;
	}

	public void setIdentifier(String identifier) {
		this.identifier = identifier;
	}

	public String getPassword() {
		return password;
	}

	public void setPassword(String password) {
		this.password = password;
	}
}