<template>
    <li>
        <input type="checkbox" v-on:change="$emit('update-todo-done', todo)" v-bind:checked="todo.completed" />
        <span class="title" contenteditable="true" v-on:keydown.enter="$emit('update-todo', $event, todo)">{{ todo.title }}</span>
        <span class="remove" v-on:click="$emit('del-todo', todo.id)">X</span>
    </li>
</template>

<script>
    export default {
        name: "TodoItem",
        props: ["todo"],
        methods: {
            markComplete() {
                this.todo.completed = !this.todo.completed;
            },
        },
    };
</script>

<style scoped>
    .title {
        display: inline-block;
        width: 250px;
        border: 1px solid transparent;
        padding: 8px;
        font-size: 16px;
        vertical-align: middle;
    }

        .title:hover {
            border: 1px solid #c4c4c4;
            border-radius: 10px;
        }

    .remove {
        cursor: pointer;
        display: inline-block;
        border: 1px solid #c4c4c4;
        padding: 0px 4px;
    }

        .remove:hover {
            background: #cc435a;
        }
</style>
