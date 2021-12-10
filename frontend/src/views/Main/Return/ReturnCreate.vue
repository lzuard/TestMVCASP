<template>
  <showcase-create v-bind="createData" @onSend="sendToServer" />
</template>

<script>
import ShowcaseCreate from '@/components/Showcase/showcase-create'
import {
  required
} from '@/utils/validation/i18n-validators'

export default {
  name: 'ReturnCreate',
  components: {
    ShowcaseCreate
  },
  data: () => {
    return {
      createData: {
        title: 'Создать возврат',
        fields: [
          {
            label: 'Номер ТТН заказа',
            placeholder: 'ТТН',
            modelValue: 'ttnOrder',
            validation: { required }
          },
          {
            label: 'Дата возврата',
            placeholder: 'Дата возврата',
            type: 'date',
            modelValue: 'returnDate',
            validation: { required }
          },
          {
            label: 'Номер ТТН возврата',
            placeholder: 'ТТН',
            modelValue: 'ttnReturn',
            validation: { required }
          },
          {
            label: 'Номер акта возврата',
            placeholder: 'Акт',
            modelValue: 'actOfReturn',
            validation: { required }
          },
          {
            label: 'Принято',
            modelValue: 'accept',
            type: 'checkbox',
            cols: ['col-auto'],
            validation: { required }
          }
        ]
      }
    }
  },
  methods: {
    async sendToServer () {}
  }
}
</script>
