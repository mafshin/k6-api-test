# Sample API Testing with K6

This is a sample usage of K6 for Api Testing.

## Sample API

API is a simple .NET Core Api for managing school information like students and teachers. For running the test the API must be running on port 5000 of the host (by default, can be configured in future).

## K6
[k6](https://k6.io/docs/) is a developer-centric, free and open-source load testing tool built for making performance testing a productive and enjoyable experience.

Here we use it for easy api testing and later for performance testing.


## How to run?

To run the tests against your API, have your sample API running in your machine and listening on port 5000 (default), then issue the following command to run the tests inside a K6 container.

- Windows (Powershell)
```
docker run -v ${PWD}/Tests:/tests loadimpact/k6 run /tests/test-students.js
```

### What routes are tests ?

- Students - "api/students"
  - Get list of students (GET) - (api/students)
  - Add a student (POST) - (api/students)
  - Get a specific student by id (GET) (api/students/id)
  - Remove a specific student by id (DELETE) (api/students/id)


## Configurations:
- Defults
  -  Url: http://localhost:5000

If you're works as described by tests, then you will get a 100% passing rate similar to this:

```

  execution: local
     script: /tests/test-students.js
     output: json (/tests/Output/summary.json)

  scenarios: (100.00%) 1 scenario, 1 max VUs, 10m30s max duration (incl. graceful stop):
           * default: 1 iterations for each of 1 VUs (maxDuration: 10m0s, gracefulStop: 30s)


running (00m00.1s), 0/1 VUs, 1 complete and 0 interrupted iterations
default ✓ [ 100% ] 1 VUs  00m00.1s/10m0s  1/1 iters, 1 per VU

     ✓ is status 200
     ✓ length of students list is 0
     ✓ id of new student is not null
     ✓ first name of new student is Wiliam
     ✓ last name of new student is Max
     ✓ length of students list is 1

     checks.........................: 100.00% ✓ 8         ✗ 0
```