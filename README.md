UI TESTS
Positive:
1. Create valid project
2. Create project dialog window displays
3. Summary field boundary values
4. Delete valid project
5. Tooltip notification whew project deleting
6. Upload file into project

Negative:
1. Create invalid project (without required Name)
2. Summary field boundary values
3. Bug imitation


API TESTS
Positive:
1. Get valid project (GET api/v1/projects/{project_id})
2. Get valid testrun (GET api/v1/runs/{run_id})
3. Create valid testrun (POST api/v1/projects/{project_id}/automation/runs)

Negative:
1. GetInvalidProject (GET api/v1/projects/{project_id})
