'''
You are presented with a map of a kingdom. Empty land on this map is depicted as ‘.’ (without the quotes), 
and mountains are depicted by ‘#’. This kingdom has factions whose armies are represented by lowercase 
letters in the map. Two armies of the same letter belong to the same faction.

Armies can go up, down, left, and right, but cannot travel through mountains. A region is an area enclosed 
by mountains. From this it can be deduced that armies cannot travel between different regions. A region is 
said to be controlled by a faction if it’s the only faction with an army in that region. If there are at 
least two armies from different factions in a region, then that region is said to be contested. Your task 
is to determine how many regions each faction controls and how many contested regions there are.

Input:

The first line is the number of test cases T. Each test case will have two numbers N and M, each on their 
own line given in that order. Following that is N lines of M characters that represent the map.

Output:

For each test case, output one line of the form “Case C:” (without the quotes), where C is the case 
number (starting from 1). On the following lines, output the factions that appear in the grid in 
alphabetical order if the faction controls at least one region and how many regions that letter controls. 
Factions that don’t control any regions should not be in the output. After this, print one last line of 
the form “contested K” where K is the number of regions that contain at least two distinct letters.

See the sample output below for details.

Constraints:

1 ≤ T ≤ 100
1 ≤ N ≤ 100
1 ≤ M ≤ 100

Sample Input:

2
2
2
.#
#a
12
15
###########....
#.......c.###..
####......#.#..
.#.########.#..
##...#..b#..#..
#.a.#...#...###
####.#.#d###..#
......#...e#xx#
.#....#########
.#.x..#..#.....
.######.c#.....
......####.....
Sample Output:

Case 1:
a 1
contested 0
Case 2:
a 1
b 1
c 2
x 2
contested 1
'''


with open('kingdomfaction.in') as f:
    lines = f.readlines()

    cases = []
    case = {}

    totaltest = int(lines[0])
    testcaseT = True

   
    
    V = []
    VAll = []
    nextC=1
    for index in range(0, totaltest):
        Mc = int(lines[nextC])
        Nr = int(lines[nextC+1])


        V.clear()
        VAll.clear()
        for i in range(nextC+2, nextC+2+Mc):
            V.append(lines[i].replace('\n',''))
        VAll.extend(V)
        nextC += Mc+2
        
        army = {}
        regions=[]
        region = []
        exclude = ['##','#', '\n']

        #read non # (elseword army/region)
        for row in range(len(V)):
            region.clear()
            Vrow =V[row]
            for col in range(len(Vrow)):
                Vcol = Vrow[col] 

                if Vcol not in exclude: 
                    region.append([row, col+1])
                elif Vrow[col-1] not in exclude and col>0 and Vcol not in exclude:
                    region.append([row, col])
            
                


                if Vcol not in ['#','.', '\n']:
                        
                    if Vcol in army.keys():
                        army[Vcol] += 1
                    else:
                        army[Vcol] = 1
            regions.extend(region.copy())
            

        #collect all group on line x to array group
        areax =[]
        st = regions[0]
        idx = 0
        areax.append([st])
        for t in range(1, len(regions)): 
            reg =regions[t]
            if reg[1]-1 == st[1] and  reg[0]== st[0]:
                areax[idx].append(regions[t])
            else:
                idx+=1
                areax.append([regions[t]])
            
            st = regions[t]

        # assign all line of group to single group        
        for i in range(len(areax)-1):
            for j in range(i+1, len(areax)-1):
                for ii in areax[i]:
                    for jj in areax[j]:
                        if ii[0]+1 == jj[0] and ii[1] == jj[1]:
                            areax[i].extend(areax[j])
                            areax[j].clear()
        
        
        #cleaning empty [] on areax
        area=[]
        for h in areax:
            if len(h)>0:
                area.append(h)

        #collect all char by region group
        group = {}
        for al in range(len(area)):
            a=area[al]
            for b in a:
                char = VAll[b[0]][b[1]-1]
                if char not in ["#", "."]:
                    if al in group.keys():
                        group[al] += char    
                    else:
                        group[al] = char
        
        #for test output
        contested = 0
        controlled = {}
        for k in group.keys():
            v = group[k]
            if len(v)>1:
                con = False
                for c in range(len(v)-1):
                    for d in range(c-1, len(v)-1):
                        if v[c] != v[d]:
                            con= True
                    if con:
                        contested +=1
                    else:
                        if v[0] in controlled.keys():
                            controlled[v[0]] +=1
                        else:
                            controlled[v[0]] = 1
                        break

            else:
                if v in controlled.keys():
                    controlled[v] +=1
                else:
                    controlled[v] = 1

        #print output test
        print('Case %s:'%(index+1))
        keys = controlled.keys()
        for k in sorted(keys) :
            print('%s %s' % (k, controlled[k]))

        print('contested %s' % contested)
        

        

        

    