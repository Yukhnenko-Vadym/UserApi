import io.restassured.RestAssured;
import io.restassured.http.ContentType;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;

import static io.restassured.RestAssured.*;
import static org.hamcrest.Matchers.*;

public class UserApiTests {

    @BeforeAll
    public static void setup() {
        RestAssured.baseURI = "http://localhost";
        RestAssured.port = 5258;
        RestAssured.basePath = "/api/v1";
    }

    @Test
    public void createValidUser() {
        given()
                .contentType(ContentType.JSON)
                .body("""
                {
                    "fullName": "Some User",
                    "email": "testuser@example.com",
                    "dateOfBirth": "1995-07-15"
                }
            """)
                .when()
                .post("/users")
                .then()
                .statusCode(201)
                .body("id", notNullValue())
                .body("email", equalTo("testuser@example.com"));
    }

    @Test
    public void createInvalidUser() {
        given()
                .contentType(ContentType.JSON)
                .body("""
                {
                    "fullName": "1",
                    "email": "invalid",
                    "dateOfBirth": "3000-01-01"
                }
            """)
                .when()
                .post("/users")
                .then()
                .statusCode(400)
                .body("errors", not(empty()));
    }
}

