webpackJsonp([2],{"7T89":function(n,t,o){"use strict";function e(n){o("G00w")}var i={data:function(){return{}},methods:{close:function(){this.$emit("close")},goPersonalInfo:function(n){this.$router.push({path:"/personalInfo",query:{id:n}})}},created:function(){},components:{}},A=function(){var n=this,t=n.$createElement,e=n._self._c||t;return e("div",{staticClass:"food-page-cover"},[e("div",{staticClass:"cover"}),n._v(" "),e("div",{staticClass:"food-content"},[e("div",{staticClass:"close-wrap",on:{click:n.close}},[e("img",{staticClass:"close",attrs:{src:o("JA1j"),alt:""}})]),n._v(" "),e("img",{staticClass:"wen",attrs:{src:o("mBvb"),alt:""}}),n._v(" "),e("div",{staticClass:"food-wrap"},[e("img",{attrs:{src:o("ACUT"),alt:""},on:{click:function(t){n.goPersonalInfo(0)}}}),n._v(" "),e("img",{attrs:{src:o("tOmX"),alt:""},on:{click:function(t){n.goPersonalInfo(1)}}})])])])},a=[],s={render:A,staticRenderFns:a},r=s,c=o("vSla"),C=e,l=c(i,r,!1,C,null,null);t.a=l.exports},ACUT:function(n,t,o){n.exports=o.p+"static/img/biao.9ae26a2.png"},AJ8K:function(n,t,o){n.exports=o.p+"static/img/sharetip.e9beb4f.png"},Eg0l:function(n,t,o){"use strict";function e(n){o("umXq")}var i={data:function(){return{}},methods:{close:function(){this.$emit("closeShare")}},components:{}},A=function(){var n=this,t=n.$createElement,e=n._self._c||t;return e("div",{staticClass:"share-page-cover"},[e("div",{staticClass:"cover"}),n._v(" "),e("div",{staticClass:"food-content"},[e("img",{staticClass:"share-tip",attrs:{src:o("AJ8K"),alt:""}}),n._v(" "),e("button",{on:{click:n.close}})])])},a=[],s={render:A,staticRenderFns:a},r=s,c=o("vSla"),C=e,l=c(i,r,!1,C,null,null);t.a=l.exports},Flqj:function(n,t,o){"use strict";function e(n){o("sohL")}Object.defineProperty(t,"__esModule",{value:!0});var i=o("7T89"),A=o("Eg0l"),a=o("Q+KX"),s=o("rAHu"),r=(i.a,A.a,a.a,s.a,{data:function(){return{showFood:!1,showShare:!1,tabIndex:2}},methods:{closeCover:function(){this.showFood=!1},closeShareCover:function(){this.showShare=!1}},created:function(){document.title="热门景区"},components:{food:i.a,share:A.a,Tabbar:a.a,TabbarItem:s.a}}),c=function(){var n=this,t=n.$createElement,e=n._self._c||t;return e("div",{staticClass:"jq-page"},[e("img",{staticClass:"img-bg",attrs:{src:o("k3/R"),alt:""}}),n._v(" "),e("tabbar",{staticClass:"tab-bar",model:{value:n.tabIndex,callback:function(t){n.tabIndex=t},expression:"tabIndex"}},[e("tabbar-item",{attrs:{link:"/"}},[e("img",{staticClass:"tab-item-new",attrs:{slot:"icon",src:o("iFoD")},slot:"icon"}),n._v(" "),e("img",{staticClass:"tab-item-new",attrs:{slot:"icon-active",src:o("3NZ+")},slot:"icon-active"}),n._v(" "),e("span",{attrs:{slot:"label"},slot:"label"},[n._v("旅游年卡")])]),n._v(" "),e("tabbar-item",{attrs:{link:"/sc"}},[e("img",{staticClass:"tab-item-new",attrs:{slot:"icon",src:o("YY4J")},slot:"icon"}),n._v(" "),e("img",{staticClass:"tab-item-new",attrs:{slot:"icon-active",src:o("trEG")},slot:"icon-active"}),n._v(" "),e("span",{attrs:{slot:"label"},slot:"label"},[n._v("年卡订购")])]),n._v(" "),e("tabbar-item",{attrs:{link:"/rmjq"}},[e("img",{attrs:{slot:"icon",src:o("6tLM")},slot:"icon"}),n._v(" "),e("img",{attrs:{slot:"icon-active",src:o("37vy")},slot:"icon-active"}),n._v(" "),e("span",{attrs:{slot:"label"},slot:"label"},[n._v("热门景区")])])],1)],1)},C=[],l={render:c,staticRenderFns:C},p=l,f=o("vSla"),d=e,m=f(r,p,!1,d,null,null);t.default=m.exports},G00w:function(n,t,o){var e=o("RKd6");"string"==typeof e&&(e=[[n.i,e,""]]),e.locals&&(n.exports=e.locals);o("FIqI")("18838c92",e,!0,{})},JA1j:function(n,t){n.exports="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACQAAAAiCAYAAAA3WXuFAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAA4RpVFh0WE1MOmNvbS5hZG9iZS54bXAAAAAAADw/eHBhY2tldCBiZWdpbj0i77u/IiBpZD0iVzVNME1wQ2VoaUh6cmVTek5UY3prYzlkIj8+IDx4OnhtcG1ldGEgeG1sbnM6eD0iYWRvYmU6bnM6bWV0YS8iIHg6eG1wdGs9IkFkb2JlIFhNUCBDb3JlIDUuNi1jMTM4IDc5LjE1OTgyNCwgMjAxNi8wOS8xNC0wMTowOTowMSAgICAgICAgIj4gPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4gPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9IiIgeG1sbnM6eG1wTU09Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9tbS8iIHhtbG5zOnN0UmVmPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvc1R5cGUvUmVzb3VyY2VSZWYjIiB4bWxuczp4bXA9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC8iIHhtcE1NOk9yaWdpbmFsRG9jdW1lbnRJRD0ieG1wLmRpZDozMGIzMzRjNS1mNTY5LWM0NDEtOTUzMS01ZTBmMDU5NmYzMTIiIHhtcE1NOkRvY3VtZW50SUQ9InhtcC5kaWQ6RUUzMzhFOEY5M0JFMTFFODk2QTg4NjRBOTVBMjU4NEQiIHhtcE1NOkluc3RhbmNlSUQ9InhtcC5paWQ6RUUzMzhFOEU5M0JFMTFFODk2QTg4NjRBOTVBMjU4NEQiIHhtcDpDcmVhdG9yVG9vbD0iQWRvYmUgUGhvdG9zaG9wIENDIDIwMTcgKFdpbmRvd3MpIj4gPHhtcE1NOkRlcml2ZWRGcm9tIHN0UmVmOmluc3RhbmNlSUQ9InhtcC5paWQ6NGI0YzMyNzUtN2I1OS05MTQ0LWE4MTktNjQxYzBkYjQ1M2U2IiBzdFJlZjpkb2N1bWVudElEPSJhZG9iZTpkb2NpZDpwaG90b3Nob3A6NGY0NTVkYTktOGYxMy0xMWU4LWE1ZTEtODI1YzUyNjE4OGVjIi8+IDwvcmRmOkRlc2NyaXB0aW9uPiA8L3JkZjpSREY+IDwveDp4bXBtZXRhPiA8P3hwYWNrZXQgZW5kPSJyIj8+zP7IKwAAA+VJREFUeNqkmGtIFFEUx4/j+lp1Mw1fRFCoIAUGiQi1okZFWaBBUfRFISTTyCDoIfUlpBcmRCIF9aEHpZAapUUGUopBayj0+BCV1gfZTNN21TWfnbvN1OzMPXem8cD/gzPHM789995zzkzQnqtfgGNpqA2ynKh41GtUJ6pLlg+MbY0mjkMTo/tu6YqAfwjiAJWg6lFhggd9RJWhngl8jqIusGcIfHpYHITqUS5IGgcGcsMAhlkKqh11gLjfhLpoAMMsE+Xae+1rJg/omOABlLEfUK651oEqshAnAIit8TmwZldUUI9QuRZiZGKWCrRAizEG1YYqWEQMP4NNBJSeFAalOXHgiJCgf3gaLj0dhsnpeSrgVupG9io77MuOgYgQCd4NTkFt+zAJpJyyn/KRDLDrxcvBHvpvmw15Z6Gq2Q3jU/Omf/bG9CjY74wNuIbLQ7lLknwSHLy7ahhm8dE2qC5MhKhwydwapEbqYH7NLlDuk3j8F1hk5uHieXwamtZdi3eYg8pJi4TyvDjd9TAbWQnsmLkgJWonz+P8kyH/MlFQjohgbuTNq6OhLDeOe6+l10MBdSkZArmM68yLe+VUyzcY8vChzhQmQFSYpMtMyfql3Cc+6PNAg2uMBFIfe/aHm+fl8c1BVYubD8X2VFEihIf8WQYn7hkqMwzm3qsx0SoHAH2XexPX2KkioTBTVQUJsAWX6WCeZZjbuFyt2tbRgjpkCMXZUynxoVBMLFNzryHMZ3UyJE7FPSyCOnGfD0XBNLqEMP2otZidcQqI2WVUBVkssFIfR6j3WHEpY7Xm1stRMzAZCOMNqIyEc53cKLnmQ6jnHybIJ00jUNsbr1ECa9hB1pVqwvkharuoApfmxJJPisaiWbM7SVfpBVOCEKjDCIZV4GBJPHslx4TA2Z2JhlBYnStFQI2ieYY1ynLiaM/MLXBLAoMyaDO1CFXMA6pG7SIzk6JvlIrd7B6FIw2DMDw+a7X31SNUqhpoG+qkCKY8ny56j996YWQcK3qT2ypUuDIPGU6M/mXKN1eBPax4IhSDo6Bi7MHCiVEIlLXSTi4T1Q48/oZMt5nTOxIoIKcayMnzqNy0zFJvGp2kG3LSEhv1b6nKPESe3yBrjdKwIYtMmRi585BrYBJ8M/N/ZRZGCzWALwhKjB8Tc5T7IBvQbKpZRLeP2FvGYs3fkJvcZlw7tQPaYmxA1JBNWpf6vaxV/rqxzkIg/wjBDpiqR1kGUleqMoswGSqYOouZqsD906cFYq9CWXKmzNgdGcbLGV12o0b+A6ZO9H3I//Kg+dCk3njKx6YXBg9K1sRIUWqnOo6SGcV+CzAAeHOWjwdpHT8AAAAASUVORK5CYII="},Kdgf:function(n,t,o){t=n.exports=o("UTlt")(!0),t.push([n.i,"\n.jq-page {\n  background: #e5efff;\n}\n.jq-page .img-bg {\n  width: 100%;\n}\n.jq-page .sc-btn {\n  position: absolute;\n  top: 10.46875rem;\n  display: -webkit-box;\n  display: -webkit-flex;\n  display: flex;\n  width: 100%;\n  height: 1.09375rem;\n  -webkit-box-pack: justify;\n  -webkit-justify-content: space-between;\n          justify-content: space-between;\n  padding: 0 1.25rem;\n  box-sizing: border-box;\n}\n.jq-page .sc-btn img {\n  width: 3.28125rem;\n}","",{version:3,sources:["E:/work/分销/shareSell/src/pages/rmjq.vue"],names:[],mappings:";AACA;EACE,oBAAoB;CACrB;AACD;EACE,YAAY;CACb;AACD;EACE,mBAAmB;EACnB,iBAAiB;EACjB,qBAAqB;EACrB,sBAAsB;EACtB,cAAc;EACd,YAAY;EACZ,mBAAmB;EACnB,0BAA0B;EAC1B,uCAAuC;UAC/B,+BAA+B;EACvC,mBAAmB;EACnB,uBAAuB;CACxB;AACD;EACE,kBAAkB;CACnB",file:"rmjq.vue",sourcesContent:["\n.jq-page {\n  background: #e5efff;\n}\n.jq-page .img-bg {\n  width: 100%;\n}\n.jq-page .sc-btn {\n  position: absolute;\n  top: 10.46875rem;\n  display: -webkit-box;\n  display: -webkit-flex;\n  display: flex;\n  width: 100%;\n  height: 1.09375rem;\n  -webkit-box-pack: justify;\n  -webkit-justify-content: space-between;\n          justify-content: space-between;\n  padding: 0 1.25rem;\n  box-sizing: border-box;\n}\n.jq-page .sc-btn img {\n  width: 3.28125rem;\n}"],sourceRoot:""}])},P9NU:function(n,t,o){t=n.exports=o("UTlt")(!0),t.push([n.i,"\n.share-page-cover {\n  position: fixed;\n  top: 0;\n  bottom: 0;\n  width: 100%;\n  z-index: 9999;\n  overflow: hidden;\n}\n.share-page-cover .cover {\n  position: absolute;\n  top: 0;\n  bottom: 0;\n  width: 100%;\n  background: #000;\n  opacity: 0.6;\n}\n.share-page-cover .food-content {\n  position: fixed;\n  top: 0.78125rem;\n  left: 50%;\n  -webkit-transform: translateX(-50%);\n          transform: translateX(-50%);\n  width: 100%;\n  text-align: right;\n}\n.share-page-cover .food-content .share-tip {\n  width: 100%;\n}\n.share-page-cover .food-content button {\n  width: 6.25rem;\n  height: 3.125rem;\n  position: absolute;\n  left: 50%;\n  bottom: 0;\n  -webkit-transform: translateX(-50%);\n          transform: translateX(-50%);\n  opacity: 0;\n}","",{version:3,sources:["E:/work/分销/shareSell/src/components/share.vue"],names:[],mappings:";AACA;EACE,gBAAgB;EAChB,OAAO;EACP,UAAU;EACV,YAAY;EACZ,cAAc;EACd,iBAAiB;CAClB;AACD;EACE,mBAAmB;EACnB,OAAO;EACP,UAAU;EACV,YAAY;EACZ,iBAAiB;EACjB,aAAa;CACd;AACD;EACE,gBAAgB;EAChB,gBAAgB;EAChB,UAAU;EACV,oCAAoC;UAC5B,4BAA4B;EACpC,YAAY;EACZ,kBAAkB;CACnB;AACD;EACE,YAAY;CACb;AACD;EACE,eAAe;EACf,iBAAiB;EACjB,mBAAmB;EACnB,UAAU;EACV,UAAU;EACV,oCAAoC;UAC5B,4BAA4B;EACpC,WAAW;CACZ",file:"share.vue",sourcesContent:["\n.share-page-cover {\n  position: fixed;\n  top: 0;\n  bottom: 0;\n  width: 100%;\n  z-index: 9999;\n  overflow: hidden;\n}\n.share-page-cover .cover {\n  position: absolute;\n  top: 0;\n  bottom: 0;\n  width: 100%;\n  background: #000;\n  opacity: 0.6;\n}\n.share-page-cover .food-content {\n  position: fixed;\n  top: 0.78125rem;\n  left: 50%;\n  -webkit-transform: translateX(-50%);\n          transform: translateX(-50%);\n  width: 100%;\n  text-align: right;\n}\n.share-page-cover .food-content .share-tip {\n  width: 100%;\n}\n.share-page-cover .food-content button {\n  width: 6.25rem;\n  height: 3.125rem;\n  position: absolute;\n  left: 50%;\n  bottom: 0;\n  -webkit-transform: translateX(-50%);\n          transform: translateX(-50%);\n  opacity: 0;\n}"],sourceRoot:""}])},RKd6:function(n,t,o){t=n.exports=o("UTlt")(!0),t.push([n.i,"\n.food-page-cover {\n  position: fixed;\n  top: 0;\n  bottom: 0;\n  width: 100%;\n  z-index: 9999;\n  overflow: hidden;\n  /*   @keyframes foodAnimate\n     {\n       0%   {\n         position: fixed;\n         top:0%;\n         left: 50%;\n         transform: translate(-50%,-50%);\n       }\n       100% {\n         position: fixed;\n         top:43%;\n         left: 50%;\n         transform: translate(-50%,-50%);\n       }\n     }\n */\n}\n.food-page-cover .cover {\n  position: absolute;\n  top: 0;\n  bottom: 0;\n  width: 100%;\n  background: #000;\n  opacity: 0.6;\n}\n@-webkit-keyframes foodAnimate {\n0% {\n    position: fixed;\n    top: 0%;\n    left: 50%;\n    -webkit-transform: translate(-50%, -50%);\n            transform: translate(-50%, -50%);\n}\n100% {\n    position: fixed;\n    top: 43%;\n    left: 50%;\n    -webkit-transform: translate(-50%, -50%);\n            transform: translate(-50%, -50%);\n}\n}\n@keyframes foodAnimate {\n0% {\n    position: fixed;\n    top: 0%;\n    left: 50%;\n    -webkit-transform: translate(-50%, -50%);\n            transform: translate(-50%, -50%);\n}\n100% {\n    position: fixed;\n    top: 43%;\n    left: 50%;\n    -webkit-transform: translate(-50%, -50%);\n            transform: translate(-50%, -50%);\n}\n}\n.food-page-cover .food-content {\n  position: fixed;\n  top: 43%;\n  left: 50%;\n  -webkit-transform: translate(-50%, -50%);\n          transform: translate(-50%, -50%);\n  -webkit-animation: foodAnimate 0.2s;\n          animation: foodAnimate 0.2s;\n  width: 80%;\n  text-align: right;\n}\n.food-page-cover .food-content .wen {\n  width: 7.8125rem;\n  margin-bottom: 0.46875rem;\n}\n.food-page-cover .food-content .close {\n  width: 0.46875rem;\n}\n.food-page-cover .food-content .close-wrap {\n  width: 1.09375rem;\n  height: 1.09375rem;\n  float: right;\n}\n.food-page-cover .food-content .food-wrap {\n  display: -webkit-box;\n  display: -webkit-flex;\n  display: flex;\n  width: 7.8125rem;\n  -webkit-box-pack: justify;\n  -webkit-justify-content: space-between;\n          justify-content: space-between;\n  padding: 0 0.3125rem;\n  box-sizing: border-box;\n}\n.food-page-cover .food-content .food-wrap img {\n  width: 3.125rem;\n  height: 4.8125rem;\n}","",{version:3,sources:["E:/work/分销/shareSell/src/components/food.vue"],names:[],mappings:";AACA;EACE,gBAAgB;EAChB,OAAO;EACP,UAAU;EACV,YAAY;EACZ,cAAc;EACd,iBAAiB;EACjB;;;;;;;;;;;;;;;GAeC;CACF;AACD;EACE,mBAAmB;EACnB,OAAO;EACP,UAAU;EACV,YAAY;EACZ,iBAAiB;EACjB,aAAa;CACd;AACD;AACA;IACI,gBAAgB;IAChB,QAAQ;IACR,UAAU;IACV,yCAAyC;YACjC,iCAAiC;CAC5C;AACD;IACI,gBAAgB;IAChB,SAAS;IACT,UAAU;IACV,yCAAyC;YACjC,iCAAiC;CAC5C;CACA;AACD;AACA;IACI,gBAAgB;IAChB,QAAQ;IACR,UAAU;IACV,yCAAyC;YACjC,iCAAiC;CAC5C;AACD;IACI,gBAAgB;IAChB,SAAS;IACT,UAAU;IACV,yCAAyC;YACjC,iCAAiC;CAC5C;CACA;AACD;EACE,gBAAgB;EAChB,SAAS;EACT,UAAU;EACV,yCAAyC;UACjC,iCAAiC;EACzC,oCAAoC;UAC5B,4BAA4B;EACpC,WAAW;EACX,kBAAkB;CACnB;AACD;EACE,iBAAiB;EACjB,0BAA0B;CAC3B;AACD;EACE,kBAAkB;CACnB;AACD;EACE,kBAAkB;EAClB,mBAAmB;EACnB,aAAa;CACd;AACD;EACE,qBAAqB;EACrB,sBAAsB;EACtB,cAAc;EACd,iBAAiB;EACjB,0BAA0B;EAC1B,uCAAuC;UAC/B,+BAA+B;EACvC,qBAAqB;EACrB,uBAAuB;CACxB;AACD;EACE,gBAAgB;EAChB,kBAAkB;CACnB",file:"food.vue",sourcesContent:["\n.food-page-cover {\n  position: fixed;\n  top: 0;\n  bottom: 0;\n  width: 100%;\n  z-index: 9999;\n  overflow: hidden;\n  /*   @keyframes foodAnimate\n     {\n       0%   {\n         position: fixed;\n         top:0%;\n         left: 50%;\n         transform: translate(-50%,-50%);\n       }\n       100% {\n         position: fixed;\n         top:43%;\n         left: 50%;\n         transform: translate(-50%,-50%);\n       }\n     }\n */\n}\n.food-page-cover .cover {\n  position: absolute;\n  top: 0;\n  bottom: 0;\n  width: 100%;\n  background: #000;\n  opacity: 0.6;\n}\n@-webkit-keyframes foodAnimate {\n0% {\n    position: fixed;\n    top: 0%;\n    left: 50%;\n    -webkit-transform: translate(-50%, -50%);\n            transform: translate(-50%, -50%);\n}\n100% {\n    position: fixed;\n    top: 43%;\n    left: 50%;\n    -webkit-transform: translate(-50%, -50%);\n            transform: translate(-50%, -50%);\n}\n}\n@keyframes foodAnimate {\n0% {\n    position: fixed;\n    top: 0%;\n    left: 50%;\n    -webkit-transform: translate(-50%, -50%);\n            transform: translate(-50%, -50%);\n}\n100% {\n    position: fixed;\n    top: 43%;\n    left: 50%;\n    -webkit-transform: translate(-50%, -50%);\n            transform: translate(-50%, -50%);\n}\n}\n.food-page-cover .food-content {\n  position: fixed;\n  top: 43%;\n  left: 50%;\n  -webkit-transform: translate(-50%, -50%);\n          transform: translate(-50%, -50%);\n  -webkit-animation: foodAnimate 0.2s;\n          animation: foodAnimate 0.2s;\n  width: 80%;\n  text-align: right;\n}\n.food-page-cover .food-content .wen {\n  width: 7.8125rem;\n  margin-bottom: 0.46875rem;\n}\n.food-page-cover .food-content .close {\n  width: 0.46875rem;\n}\n.food-page-cover .food-content .close-wrap {\n  width: 1.09375rem;\n  height: 1.09375rem;\n  float: right;\n}\n.food-page-cover .food-content .food-wrap {\n  display: -webkit-box;\n  display: -webkit-flex;\n  display: flex;\n  width: 7.8125rem;\n  -webkit-box-pack: justify;\n  -webkit-justify-content: space-between;\n          justify-content: space-between;\n  padding: 0 0.3125rem;\n  box-sizing: border-box;\n}\n.food-page-cover .food-content .food-wrap img {\n  width: 3.125rem;\n  height: 4.8125rem;\n}"],sourceRoot:""}])},"k3/R":function(n,t,o){n.exports=o.p+"static/img/rmjq.f89d6c3.png"},mBvb:function(n,t,o){n.exports=o.p+"static/img/wen.f0d9ccc.png"},sohL:function(n,t,o){var e=o("Kdgf");"string"==typeof e&&(e=[[n.i,e,""]]),e.locals&&(n.exports=e.locals);o("FIqI")("21c5cd5d",e,!0,{})},tOmX:function(n,t,o){n.exports=o.p+"static/img/hao.8fbcb30.png"},umXq:function(n,t,o){var e=o("P9NU");"string"==typeof e&&(e=[[n.i,e,""]]),e.locals&&(n.exports=e.locals);o("FIqI")("6058ce8d",e,!0,{})}});
//# sourceMappingURL=2.c6dc7029f81af65c2eb8.js.map