接口调用说明:
1. 注册用户
	POST: http://localhost:52570/api/Account/Register
	Headers:
		Content-Type: application/x-www-form-urlencoded
	Body:
		username=lj&password=asiapeaK_1&confirmpassword=asiapeaK_1&email=123%40qq.com
2. 获取access_token及refresh_token
	POST: http://localhost:52570/oauth/token
	Headers:
		Content-Type: application/x-www-form-urlencoded
	Body:
		grant_type=password&username=lj&password=asiapeaK_1&client_id=B9684437-B69A-45BF-BDC6-FD6EEC14026A&client_secret=e4d6d94a8891f319f69fc6328d28e29f
3. 使用refresh_token刷新access_token
	POST:http://localhost:52570/oauth/token
	Headers:
		Content-Type: application/x-www-form-urlencoded
	Body:
		grant_type=refresh_token&client_id=B9684437-B69A-45BF-BDC6-FD6EEC14026A&refresh_token=adbbf17aeb2c4429bf2170bacfe7d1db
4. 获取订单数据(需要admin角色)
	GET: http://localhost:52570/api/order
	Headers:
		Content-Type: application/x-www-form-urlencoded
		Authorization: Bearer 8ya4Db-ooJA_sUJIlInAMpnMLcvpBZzp46X1hVK4q96NIR9qklx1VIkarHWQPlo4EU6de7SCc277blbmu7LDi52-uRxk8mzgPvVS53h6LyvPHaeWwzHHhkh7UAwwLZBoRwPr56VbFlkIIxr1TBCjyVr63Zj0gYDNDkRupeoD28eHwRwKioZEKSCZ1CVuZt_w29PiFfx87DrNGHcBDntiY8GcqrkkEj5PJzHY-7MRotX2ImytJMTatg0W3Fn_KOeNmanWCvAZ0K6cgz8pgK0QOIUyB8rnvco9hdBnGfR3q_rbR_kGUgqHIHgSxynOlCOt4RlWxbDQ6IMxQVVnScavZAQYuFcAsCvuazEBVKEKQeKV7mcIaFtC4WRVsr2sNO5t
5. 查看所有refresh_token(需要admin角色)
	GET: http://localhost:52570/api/RefreshToken
	Headers:
		Content-Type: application/x-www-form-urlencoded
		Authorization: Bearer 8ya4Db-ooJA_sUJIlInAMpnMLcvpBZzp46X1hVK4q96NIR9qklx1VIkarHWQPlo4EU6de7SCc277blbmu7LDi52-uRxk8mzgPvVS53h6LyvPHaeWwzHHhkh7UAwwLZBoRwPr56VbFlkIIxr1TBCjyVr63Zj0gYDNDkRupeoD28eHwRwKioZEKSCZ1CVuZt_w29PiFfx87DrNGHcBDntiY8GcqrkkEj5PJzHY-7MRotX2ImytJMTatg0W3Fn_KOeNmanWCvAZ0K6cgz8pgK0QOIUyB8rnvco9hdBnGfR3q_rbR_kGUgqHIHgSxynOlCOt4RlWxbDQ6IMxQVVnScavZAQYuFcAsCvuazEBVKEKQeKV7mcIaFtC4WRVsr2sNO5t
6. 删除指定refresh_token(需要admin角色)
	DELETE: http://localhost:52570/api/RefreshToken?tokenid=3e0bf33b1b88496da0946a3082cd9b41
	Headers:
		Content-Type: application/x-www-form-urlencoded
		Authorization: Bearer 8ya4Db-ooJA_sUJIlInAMpnMLcvpBZzp46X1hVK4q96NIR9qklx1VIkarHWQPlo4EU6de7SCc277blbmu7LDi52-uRxk8mzgPvVS53h6LyvPHaeWwzHHhkh7UAwwLZBoRwPr56VbFlkIIxr1TBCjyVr63Zj0gYDNDkRupeoD28eHwRwKioZEKSCZ1CVuZt_w29PiFfx87DrNGHcBDntiY8GcqrkkEj5PJzHY-7MRotX2ImytJMTatg0W3Fn_KOeNmanWCvAZ0K6cgz8pgK0QOIUyB8rnvco9hdBnGfR3q_rbR_kGUgqHIHgSxynOlCOt4RlWxbDQ6IMxQVVnScavZAQYuFcAsCvuazEBVKEKQeKV7mcIaFtC4WRVsr2sNO5t
	注：DELTE链接中的查询参数tokenid是指数据库中AppRefreshTokens表中的Id(此字段是接口2或3获取的refresh_token加密后的值)字段。

注：
	通过接口2获取的access_token没有权限访问接口4、5、6，因此当前硬编码只有在用refresh_token刷新后得到的access_token才具有admin的角色声明。
	
Have been modifed from github.com.
