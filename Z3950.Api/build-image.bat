
del /a /s "./bin/Release/net6.0/publish/*.pdb"

docker build -t z3950-api:latest .