package com.example.demo.requests;

public class UserResetRequest {
				
	private String username;
	private String email;

	public UserResetRequest(String username, String email) {
		this.username = username;
		this.email = email;
	}

	public UserResetRequest() {
	}

	public String getUsername() {
		return username;
	}

	public void setUsername(String username) {
		this.username = username;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}
}