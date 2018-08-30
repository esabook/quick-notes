 
Inputmax = 9999
Inputmin = 1
Kmax = 9999
Kmin = 1 
Tmax = 100
Tmin = 1

def totalDivided(a, b, k):
    total = 0
    # b = a+1 if a > b else b
    for i in range(a, b+1):
        if i % k == 0:
            total +=1
    return total

def getCase(casenum, a, b, k):
    a = Inputmin if a < Inputmin else Inputmax if a>=Inputmax else a
    b = Inputmin if b < Inputmin else Inputmax if b>=Inputmax else b
    k = Kmin if k < Kmin else Kmax if k >= Kmax else k
    # if Inputmin <= a and a <= b and b < Inputmax:
    #     if k in range(Kmin, Kmax):
    num = totalDivided(a,b,k)
    return 'Case %s: %s' % (casenum, num)

with open('match_pattern.in') as f:
    lines = f.readlines()
    T = None

    abk = []
    CaseCounter = 1

    for l in lines:

        l = int(l)
        if not T :
            T = Tmin if l < Tmin else Tmax if l > Tmax else l
            continue
        # if T not in range(Tmin, Tmax+1):
        #     break

        abk.append(l)
        if len(abk) == 3:
            p = getCase(CaseCounter,abk[0],abk[1],abk[2])
            if p != None:
                print(p)
                CaseCounter += 1
            
            abk.clear()