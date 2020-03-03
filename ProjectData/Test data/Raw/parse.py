examiner = list(range(1,11))
categories = []

with open('./Permissions/category.txt', 'r') as reader:
    lines = reader.readlines()
    for i in range(len(lines)):
        line = lines[i].strip()
        cats = line.split(' ')
        for cat in cats:
            categories.append((examiner[i], cat))
    
with open('permissions_parsed.txt', 'w') as writer:
    writer.write('INSERT INTO dbo.Permissions (Examiner_Id, Category)\n')
    writer.write('Values\n')
    for i, c in categories:
        writer.write('(' + str(i) + ', \'' + c +'\'),\n')
