from random import randint

examiners = {
'Julian' : 1,
'Bronisław' : 2,
'Radosław' : 3,
'Mirosław' : 4,
'Korneliusz' : 5, 
'Agata' : 6,
'Klementyna' : 7, 
'Edyta' : 8,
'Balbina' : 9, 
'Barbara' : 10,
}

examiners_ids = []
examinees_ids = []
categories = []
dates = []


with open('./Future exams/future exam, examiners names.txt', 'r', encoding='utf-8') as reader:
    lines = reader.readlines()
    for line in lines:
        line = line .strip()
        assert line in examiners.keys()
        examiners_ids.append(examiners.get(line))

for _ in range(len(examiners_ids)):
    examinees_ids.append(randint(1,100))

with open('./Future exams/future exam, categories.txt', 'r') as reader:
    lines = reader.readlines()
    for line in lines:
        line = line.strip()
        categories.append(line)

with open('./Future exams/future exam, datetime.txt', 'r') as reader:
    lines = reader.readlines()
    for line in lines:
        line = line.strip()
        dates.append(line)

info = zip(examinees_ids, examiners_ids, categories, dates)
    
with open('plannedExams_parsed.txt', 'w') as writer:
    writer.write('INSERT INTO dbo.Exams (Examinee_Id, Examiner_Id, Category, Date)\n')
    writer.write('VALUES\n')
    for s_id, e_id, c, date in info:
        writer.write('(' + str(s_id) + ', ' + str(e_id) +', \'' + c + '\', \'' + date  + '\'),\n')
