using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using MW.Extensions;
using UniRx;

namespace MW.UI {
    class CharaPager : IObservable<CharaPager> {
        //定数
        public const int CHARACTER_PER_PAGE    = 6;

        //キャラファイル数
        public const int CHARACTER_FILE_NUMBER = 50;

        //インターフェイス
        public int PageCount {
            get {
                if(_needsToReload) ReloadCharacterTable();
                return _pageCount;
            }
        }

        public int CurrentPageNumber {
            get {
                if(_needsToReload) ReloadCharacterTable();
                return _currentPage;
            }
            set {
                var bak = _currentPage;
                _currentPage = value;
                if(!PageInRange()) {
                    _currentPage = bak;
                    throw new IndexOutOfRangeException("Wrong index of page.");
                }
                NotifyUpdate();
            }
        }

        public List<Character> CurrentPage {
            get {
                if(_needsToReload) ReloadCharacterTable();
                return GetCharacterOnCurrentPage();
            }
        }

        public IDisposable Subscribe(IObserver<CharaPager> observer) {
            return _pagerSubject.Subscribe(observer);
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
        private int  _pageCount             = 1;
        private int  _currentPage           = 0;

        private List<Character>             _characters;
        private Subject<CharaPager>         _pagerSubject;

        //Singletonパターンとして実装
        private static readonly CharaPager  _Instance = new CharaPager();
        
        public  static CharaPager Instance {
            get {
                return _Instance;
            }
        }
        
        private CharaPager() {
            _characters = new List<Character>();
            _pagerSubject = new Subject<CharaPager>();
        }

        private void NotifyUpdate() {
            _pagerSubject.OnNext(this);
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
