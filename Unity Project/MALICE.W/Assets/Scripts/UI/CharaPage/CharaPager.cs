using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MW.UI.Extensions;

namespace MW.UI {
    class CharaPager : IObservable<UpdateObservant<CharaPager>> {
        //定数
        public const int CHARACTER_PER_PAGE    = 6;

        //キャラファイル数
        public const int CHARACTER_FILE_NUMBER = 50;

        //Singletonパターンとして実装
        private static CharaPager _instance = new CharaPager();
        
        public  static CharaPager instance {
            get {
                return _instance;
            }
        }

        //インターフェイス
        public int pageCount {
            get {
                if(_needsToReload) ReloadCharacterTable();
                return _pageCount;
            }
        }

        public int currentPageNumber {
            get {
                if(_needsToReload) ReloadCharacterTable();
                return _currentPage;
            }
            set {
                int bak = _currentPage;
                _currentPage = value;
                if(!PageInRange()) {
                    _currentPage = bak;
                    throw new IndexOutOfRangeException("Wrong index of page.");
                }
                NotifyUpdate();
            }
        }

        public List<Character> currentPage {
            get {
                if(_needsToReload) ReloadCharacterTable();
                return GetCharacterOnCurrentPage();
            }
        }

        public T Observe<T>() where T : IObservantBase {
            if(default(T) is UpdateObservant<CharaPager>)
                return (T)(object)_pagerObserver;
            else
                return default(T);
        }

        public UpdateObservant<CharaPager> ObserveUpdate() {
            return _pagerObserver;
        }

        public void NextPage() {
            _currentPage++;
            if(PageInRange()) NotifyUpdate();
            else              _currentPage--; //revert
        }

        public void PrevPage() {
            _currentPage--;
            if(PageInRange()) NotifyUpdate();
            else              _currentPage++; //revert
        }

        public void Reload() {
            _needsToReload = true;
        }
        
        //実装
        private bool _needsToReload         = true;
        private int  _pageCount             = 0;
        private int  _currentPage           = 0;

        private List<Character> _characters = new List<Character>();
        private UpdateObservant<CharaPager> _pagerObserver;

        //コンストラクタはプライベート
        private CharaPager() {
            _pagerObserver = new UpdateObservant<CharaPager>(this);
        }

        private void NotifyUpdate() {
            _pagerObserver.NotifyUpdate();
        }
        
        private /*inline*/ bool PageInRange() {
            return (0 <= _currentPage) && (_currentPage < _pageCount);
        }

        private void ReloadCharacterTable() {
            _characters = new List<Character>();

            for (var i = 1; i <= Character.MAX_FILECOUNT; i++) { //ファイル数によって最大値を変更
                Character chara = Character.ReadFrom(i);
                if (chara.getNAME() != "") _characters.Add(chara);
            }

            int n = _characters.Count();

            _pageCount   = n / CHARACTER_PER_PAGE + (n % CHARACTER_PER_PAGE == 0 ? 0 : 1);
            _currentPage = 0;
            
            _needsToReload = false;
            NotifyUpdate();
        }

        private List<Character> GetCharacterOnCurrentPage() {
            return _characters.SpliceNd(_currentPage * CHARACTER_PER_PAGE,
                                        CHARACTER_PER_PAGE);
        }
    };
};
