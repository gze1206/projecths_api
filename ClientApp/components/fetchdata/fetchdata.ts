// @ts-ignore
import { Vue, Component } from 'vue-property-decorator';

// @ts-ignore
@Component
// @ts-ignore
export default class FetchDataComponent extends Vue {
    json: string = '';

    mounted() {
        fetch('api/card/all/')
            .then(response => {
                console.log(response);
                return response.json();
            })
            .then(data => {
                console.log(data);
                this.json = data;
            });
    }
}