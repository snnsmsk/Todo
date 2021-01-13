(function(t){function e(e){for(var n,i,a=e[0],u=e[1],c=e[2],l=0,p=[];l<a.length;l++)i=a[l],Object.prototype.hasOwnProperty.call(r,i)&&r[i]&&p.push(r[i][0]),r[i]=0;for(n in u)Object.prototype.hasOwnProperty.call(u,n)&&(t[n]=u[n]);s&&s(e);while(p.length)p.shift()();return d.push.apply(d,c||[]),o()}function o(){for(var t,e=0;e<d.length;e++){for(var o=d[e],n=!0,a=1;a<o.length;a++){var u=o[a];0!==r[u]&&(n=!1)}n&&(d.splice(e--,1),t=i(i.s=o[0]))}return t}var n={},r={app:0},d=[];function i(e){if(n[e])return n[e].exports;var o=n[e]={i:e,l:!1,exports:{}};return t[e].call(o.exports,o,o.exports,i),o.l=!0,o.exports}i.m=t,i.c=n,i.d=function(t,e,o){i.o(t,e)||Object.defineProperty(t,e,{enumerable:!0,get:o})},i.r=function(t){"undefined"!==typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(t,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(t,"__esModule",{value:!0})},i.t=function(t,e){if(1&e&&(t=i(t)),8&e)return t;if(4&e&&"object"===typeof t&&t&&t.__esModule)return t;var o=Object.create(null);if(i.r(o),Object.defineProperty(o,"default",{enumerable:!0,value:t}),2&e&&"string"!=typeof t)for(var n in t)i.d(o,n,function(e){return t[e]}.bind(null,n));return o},i.n=function(t){var e=t&&t.__esModule?function(){return t["default"]}:function(){return t};return i.d(e,"a",e),e},i.o=function(t,e){return Object.prototype.hasOwnProperty.call(t,e)},i.p="/";var a=window["webpackJsonp"]=window["webpackJsonp"]||[],u=a.push.bind(a);a.push=e,a=a.slice();for(var c=0;c<a.length;c++)e(a[c]);var s=u;d.push([0,"chunk-vendors"]),o()})({0:function(t,e,o){t.exports=o("56d7")},"034f":function(t,e,o){"use strict";o("85ec")},2356:function(t,e,o){},3671:function(t,e,o){},"56d7":function(t,e,o){"use strict";o.r(e);o("e260"),o("e6cf"),o("cca6"),o("a79d");var n=o("2b0e"),r=function(){var t=this,e=t.$createElement,o=t._self._c||e;return o("div",{attrs:{id:"app"}},[o("h1",[t._v("ToDo App")]),o("NewTodo",{on:{"new-todo":t.newTodo}}),o("Todos",{attrs:{todos:t.todos},on:{"del-todo":t.deleteTodo,"update-todo":t.updateTodo,"update-todo-done":t.updateTodoDone}})],1)},d=[],i=(o("99af"),o("4de4"),o("c740"),o("498a"),o("2909")),a=o("a65d"),u=o.n(a),c=function(){var t=this,e=t.$createElement,o=t._self._c||e;return o("ul",t._l(t.todos,(function(e){return o("TodoItem",{key:e.id,attrs:{todo:e},on:{"del-todo":function(o){return t.$emit("del-todo",e.id)},"update-todo":function(o){return t.$emit("update-todo",o,e)},"update-todo-done":function(o){return t.$emit("update-todo-done",e)}}})})),1)},s=[],l=function(){var t=this,e=t.$createElement,o=t._self._c||e;return o("li",[o("input",{attrs:{type:"checkbox"},domProps:{checked:t.todo.completed},on:{change:function(e){return t.$emit("update-todo-done",t.todo)}}}),o("span",{staticClass:"title",attrs:{contenteditable:"true"},on:{keydown:function(e){return!e.type.indexOf("key")&&t._k(e.keyCode,"enter",13,e.key,"Enter")?null:t.$emit("update-todo",e,t.todo)}}},[t._v(t._s(t.todo.title))]),o("span",{staticClass:"remove",on:{click:function(e){return t.$emit("del-todo",t.todo.id)}}},[t._v("X")])])},p=[],f={name:"TodoItem",props:["todo"],methods:{markComplete:function(){this.todo.completed=!this.todo.completed}}},h=f,m=(o("f89a"),o("2877")),v=Object(m["a"])(h,l,p,!1,null,"7a8c687e",null),w=v.exports,b={name:"Todos",components:{TodoItem:w},props:["todos"]},T=b,y=Object(m["a"])(T,c,s,!1,null,"70141ae9",null),g=y.exports,x=function(){var t=this,e=t.$createElement,o=t._self._c||e;return o("div",[o("form",{on:{submit:function(e){return e.preventDefault(),t.newTodo(e)}}},[o("input",{directives:[{name:"model",rawName:"v-model",value:t.title,expression:"title"}],attrs:{type:"text",name:"title",placeholder:"New Todo..."},domProps:{value:t.title},on:{input:function(e){e.target.composing||(t.title=e.target.value)}}})])])},$=[],O={name:"NewTodo",data:function(){return{title:""}},methods:{newTodo:function(){this.$emit("new-todo",this.title),this.title=""}}},_=O,k=(o("b5ad"),Object(m["a"])(_,x,$,!1,null,"2d228888",null)),j=k.exports,P=o("5530"),E=(o("96cf"),o("1da1")),D=o("bc3a"),N=o.n(D),S="http://localhost:42144/api",C=N.a.create({baseURL:S,timeout:1e3}),I={execute:function(t,e,o,n){return Object(E["a"])(regeneratorRuntime.mark((function r(){return regeneratorRuntime.wrap((function(r){while(1)switch(r.prev=r.next){case 0:return r.abrupt("return",C(Object(P["a"])({method:t,url:e,data:o},n)));case 1:case"end":return r.stop()}}),r)})))()},createNew:function(t,e){return this.execute("POST","todos",{title:t,completed:e})},getAll:function(){return this.execute("GET","todos",null)},update:function(t,e,o){return this.execute("PUT","todos/"+t,{title:e,completed:o})},delete:function(t){return this.execute("DELETE","todos/"+t)}};n["a"].use(u.a,{duration:2e3,position:"bottom-right"});var M={name:"Home",components:{Todos:g,NewTodo:j},data:function(){return{todos:[]}},methods:{updateTodo:function(t,e){var o=this;e.title=t.target.innerText;var n=e.title.trim();n?(t.preventDefault(),I.update(e.id,e.title.trim(),e.completed).then((function(){var r=o.todos.findIndex((function(t){return t.id==e.id}));o.todos[r].title=n,o.$toasted.show("Task Updated"),t.target.blur()})).catch((function(t){o.$toasted.show(t)}))):this.$toasted.show("Task can not be empty")},updateTodoDone:function(t){var e=this;I.update(t.id,t.title,!t.completed).then((function(){var o=e.todos.findIndex((function(e){return e.id==t.id}));e.todos[o].completed=!e.todos[o].completed,e.$toasted.show("Task Updated")})).catch((function(t){e.$toasted.show(t)}))},deleteTodo:function(t){var e=this;I.delete(t).then((function(){e.todos=e.todos.filter((function(e){return e.id!==t})),e.$toasted.show("Task Deleted")})).catch((function(t){e.$toasted.show(t)}))},newTodo:function(t){var e=this,o=t&&t.trim();o&&I.createNew(o,!1).then((function(t){e.todos=[].concat(Object(i["a"])(e.todos),[t.data]),e.$toasted.show("Task Created")})).catch((function(t){e.$toasted.show(t)}))}},created:function(){var t=this;I.getAll().then((function(e){t.todos=e.data})).catch((function(e){t.$toasted.show(e)}))}},U=M,A=(o("034f"),Object(m["a"])(U,r,d,!1,null,null,null)),R=A.exports;n["a"].config.productionTip=!0,new n["a"]({render:function(t){return t(R)}}).$mount("#app")},"85ec":function(t,e,o){},b5ad:function(t,e,o){"use strict";o("3671")},f89a:function(t,e,o){"use strict";o("2356")}});
//# sourceMappingURL=app.9e198b71.js.map