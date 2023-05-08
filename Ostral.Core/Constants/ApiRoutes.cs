namespace Ostral.Core.Constants;

public static class ApiRoutes
{
    private const string ApiBase = "/api";
        
    public static class User
    {
            
    }

    public static class Content
    {
        private const string CourseContent = $"{ApiBase}/content";

        public static string GetContentById(string contentId) => $"{CourseContent}/{contentId}";
    }

    public static class StudentCourse
    {
        private const string StudentCourseBase = $"{ApiBase}/student";

        public static string GetStudentCourses(string id) => $"{StudentCourseBase}/{id}/course";
        public static string GetStudentCourseById(string studentId, string courseId) => $"{StudentCourseBase}/{studentId}/course/{courseId}";
        public static string EnrollForACourse(string studentId, string courseId) => $"enroll_for_a_course/student/{{studentId}}/course/{{courseId}}";
    }

    public static class Student
    {
        private const string StudentBase = $"{ApiBase}/student";

        public static string GetStudentById(string id) => $"{StudentBase}/{id}";
    }
        
    public static class Course
    {
        private const string CourseBase = $"{ApiBase}/course";

        public const string GetAllCourses = CourseBase;
        public const string PopularCourses = $"{CourseBase}/popular-courses";
        public const string RandomCourse = $"{CourseBase}/random-courses";
        public static string GetCourseById(string id) => $"{CourseBase}/{id}";
        public static string EnrollForACourse(string courseId, string studentId) => $"{CourseBase}/{courseId}/student/{studentId}";
    }

    public static class Category
    {
        public const string Categories = $"{ApiBase}/category";
        public static string GetCategoryById(string categoryId) => $"{Categories}/{categoryId}";
    }
        
    public static class CategoryCourse
    {
        public static string CategoryCoursesById(string categoryId) => $"{ApiBase}/category/{categoryId}/course";
    }
    
    public static class Auth
    {
        private const string AuthBase = $"{ApiBase}/auth";
           
        public const string Login = $"{AuthBase}/login";
        public const string RegisterStudentRoute = $"{AuthBase}/register";
        public const string RegisterTutorRoute = $"{AuthBase}/register-tutor";
            
    }

    public static class Tutor
    {
        public const string Tutors = $"{ApiBase}/tutor";

        public const string PopularTutors = $"{Tutors}/popular-tutors";
    }

    public static class Search
    {
        public static string SearchByKeyword(string keyword) => $"{ApiBase}/search?keyword={keyword}";
    }

    public static class Comment
    {
            
        public static string AddComment(string courseID) => $"{ApiBase}/{courseID}/comment/addcomment";
        public static string GetCommentById(string commentId) => $"{ApiBase}/{commentId}/id";
        public static string ToggleLike(string commentId) => $"{ApiBase}/comment/{commentId}/like";
        public static string GetAllComments(string courseId) => $"{ApiBase}/{courseId}/comment/getallcomments";
    }
}