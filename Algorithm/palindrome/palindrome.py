# write with python for simple scripting
def isInt(stri):
    res = 0
    try:
        res = int(stri)
    except Exception:
        res = ""
    return type(res) == type(0)

def palindromeCount(arr, scr):
    count =0
    
    for irow in range(0, len(arr)):
        for ichar in range(0, len(arr[irow])):
            left = ''
            right =''
            up =''
            down =''
            dul =''
            dur =''
            ddl =''
            ddr =''
            for idx in range(0, len(scr)):
                plusH = ichar+idx if ichar+idx <= len(scr)+100 else None
                PlusV = irow+idx if irow+idx <= len(arr) else None
                minH = ichar-idx if ichar-idx >= 0 else None
                minV = irow-idx if  irow-idx >= 0 else None
                # FIXME
                try:
                    left +=  arr[irow][minH]
                except Exception:
                    pass 
                try:
                    right += arr[irow][plusH]
                except Exception:
                    pass 
                try:
                    up += arr[minV][ichar]
                except Exception:
                    pass 
                try:
                    down += arr[PlusV][ichar]
                except Exception:
                    pass 
                try:
                    dul += arr[minV][minH]
                except Exception:
                    pass 
                try:
                    dur += arr[minV][plusH] 
                except Exception:
                    pass 
                try:
                    ddl += arr[PlusV][minH]
                except Exception:
                    pass 
                try:
                    ddr += arr[PlusV][plusH]
                except Exception:
                    pass 
                
            text = ('%s, %s, %s, %s, %s, %s, %s, %s '% (left, right, up, down, dul, dur, ddl, ddr))
            count+=text.count(scr)
            
          
            

                
                
    
    return   count

with open('palindrome.in') as f:
    lines = f.readlines()
    clearLine =[]

    for l in lines:
        clearLine.append( l.replace('\n',''))
    
    T = int(clearLine[0]) if int(clearLine[0]) in range (1,101) else 1
    
    Counter = 0
    NMWmin = 1
    NMWmax = 100

    N = 0
    M = 0
    Wtemp = []
    W =[]

    for i in range(1, len(clearLine)):
        
        if Counter > T: 
            break 

        if N == 0 and isInt(clearLine[i]):
            N = int(clearLine[i]) 
            N = N if N in range(NMWmin, NMWmax) else NMWmin if N < NMWmin else NMWmax
            continue

        if  N != 0 and M == 0 and isInt(clearLine[i]):
            M = int(clearLine[i]) 
            M = M if M in range(NMWmin, NMWmax) else NMWmin if M < NMWmin else NMWmax
            continue

       
        if isInt(N) and type(N) == type(M): 
            if len(Wtemp) < N:
                Wtemp.append(clearLine[i])
            else:
                N = 0
                M = 0
                Counter += 1
                X = palindromeCount(Wtemp, clearLine[i])
                print('Case %s: %s' % (Counter, X))
                Wtemp =[]
