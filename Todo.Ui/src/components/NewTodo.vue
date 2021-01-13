<template>
    <div>
        <form @submit.prevent="newTodo">
            <input type="text" v-model="title" name="title" placeholder="New Todo...">
        </form>
    </div>
</template>

<script>
    export default {
        name: "NewTodo",
        data() {
            return {
                title: ''
            }
        },
        methods: {
            newTodo() {
                this.$emit('new-todo', this.title);
                this.title = '';
            }
        }
    }
</script>

<style scoped>
    form {
        display: flex;
    }

    input[type="text"] {
        flex: 10;
        padding: 5px;
        width: 280px;
    }
</style>
