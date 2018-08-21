#generate empty chara_data_*.json in the specified range

import sys
import os

PATH_TO_JSONFILES = os.path.dirname(os.path.abspath(__file__)) + "/../Unity Project/MALICE.W/Assets/Prefabs/Database/Jsonfiles"
placeholder       = '{"m_ID":%s,"m_NAME":"","m_SEX":"","m_HIGHSCORE":0,"m_PLAYTIME":0}'

def make_file(id):
    fp = open('%s/chara_data_%s.json' % (PATH_TO_JSONFILES, str(id)), 'w')
    fp.write(placeholder % str(id))
    fp.close()

def main(args):
    flag = False
    if len(args) < 2:
        flag = True
    else:
        param = args[1].split(':')
        if len(param) != 2:
            flag = True
        else:
            start = int(param[0])
            end   = int(param[1])
            print("Create file No. %d - %d..." % (start, end), end=' ')
            
            for i in range(start, end + 1):
                make_file(i)
            
            print("Done.")
        
    if flag:
        print("Usage: python %s START:END" % str(args[0]))

if __name__ == "__main__":
    main(sys.argv)
