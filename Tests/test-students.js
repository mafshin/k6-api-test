import http from 'k6/http';
import { check } from 'k6';

export default function () {
  var host = 'http://host.docker.internal:5000';
  var url = host + "/api/students";

  var payload = JSON.stringify({
    firstName: 'Wiliam',
    lastName: 'Max',
  });

  var params = {
    headers: {
      'Content-Type': 'application/json',
    },
  };


  // reset the service data
  http.post(host + "/api/students/reset", "{}", params);

  
  let res = http.get(url);

  check(res, {
    'is status 200': (r) => r.status === 200,
    'length of students list is 0': (r) => r.json().length === 0
  });

  res = http.post(url, payload, params);

  check(res, {
      'is status 200': (r) => r.status === 200,
      'id of new student is not null': (r) => r.json().id != null,
      'first name of new student is Wiliam': (r) => r.json().firstName === 'Wiliam',
      'last name of new student is Max': (r) => r.json().lastName === 'Max',
  });

  res = http.get(url);

  check(res, {
    'is status 200': (r) => r.status === 200,
    'length of students list is 1': (r) => r.json().length === 1
  });
}