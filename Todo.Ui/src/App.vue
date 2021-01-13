<template>
    <div id="app">
        <h1>ToDo App</h1>
        <NewTodo v-on:new-todo="newTodo" />
        <Todos v-bind:todos="todos"
               v-on:del-todo="deleteTodo"
               v-on:update-todo="updateTodo"
               v-on:update-todo-done="updateTodoDone" />
    </div>
</template>

<script>
    import Vue from 'vue'
    import Toasted from 'vue-toasted';
    import Todos from "./components/Todos";
    import NewTodo from "./components/NewTodo";
    import api from "./Api";

    Vue.use(Toasted, {
        duration: 2000,
        position: 'bottom-right'
    });

    export default {
        name: "Home",
        components: {
            Todos,
            NewTodo,
        },
        data() {
            return {
                todos: [],
            };
        },
        methods: {
            updateTodo(e, todo) {

                todo.title = e.target.innerText
                var value = todo.title.trim();
                if (!value) {
                    this.$toasted.show('Task can not be empty');
                    return;
                }

                e.preventDefault();

                api.update(todo.id, todo.title.trim(), todo.completed)
                    .then(() => {
                        var objIndex = this.todos.findIndex((obj) => obj.id == todo.id);
                        this.todos[objIndex].title = value;
                        this.$toasted.show('Task Updated');
                        e.target.blur();
                    })
                    .catch((error) => {
                        this.$toasted.show(error);
                    });
            },

            updateTodoDone(todo) {
                api.update(todo.id, todo.title, !todo.completed)
                    .then(() => {
                        var objIndex = this.todos.findIndex((obj) => obj.id == todo.id);
                        this.todos[objIndex].completed = !this.todos[objIndex].completed;
                        this.$toasted.show('Task Updated');
                    })
                    .catch((error) => {
                        this.$toasted.show(error);
                    });
            },
            deleteTodo(id) {
                api
                    .delete(id)
                    .then(() => {
                        this.todos = this.todos.filter((todo) => todo.id !== id);
                        this.$toasted.show('Task Deleted');
                    })
                    .catch((error) => {
                        this.$toasted.show(error);
                    });
            },
            newTodo(newTodo) {
                var value = newTodo && newTodo.trim();
                if (!value) {
                    return;
                }

                api.createNew(value, false)
                    .then((response) => {
                        this.todos = [...this.todos, response.data];
                        this.$toasted.show('Task Created');
                    })
                    .catch((error) => {
                        this.$toasted.show(error);
                    });
            },
        },
        created() {
            api
                .getAll()
                .then((response) => {
                    this.todos = response.data;
                })
                .catch((error) => {
                    this.$toasted.show(error);
                });
        },
    };
</script>

<style>
    * {
        box-sizing: border-box;
        margin: 0;
        padding: 0;
    }

    h1 {
        font-weight: bold;
        font-size: 28px;
        text-align: center;
    }

    body {
        margin: 0;
        padding: 0;
        width: 100%;
        display: flex;
        justify-content: center;
        align-items: flex-start;
    }

    .btn {
        display: inline-block;
        border: none;
        background: #555;
        color: #fff;
        padding: 7px 20px;
        cursor: pointer;
    }

        .btn:hover {
            background: #666;
        }
</style>