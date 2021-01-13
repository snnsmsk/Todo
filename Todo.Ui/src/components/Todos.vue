<template>
    <ul>
        <TodoItem v-bind:key="todo.id"
                  v-for="todo in todos"
                  v-bind:todo="todo"
                  v-on:del-todo="$emit('del-todo', todo.id)"
                  v-on:update-todo="$emit('update-todo', $event, todo)"
                  v-on:update-todo-done="$emit('update-todo-done', todo)" />
    </ul>
</template>

<script>
    import TodoItem from "./TodoItem.vue";
    export default {
        name: "Todos",
        components: {
            TodoItem,
        },
        props: ["todos"],
    };
</script>

<style scoped>
</style>